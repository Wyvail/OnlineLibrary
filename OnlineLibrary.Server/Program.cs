using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Server.Data;
using OnlineLibrary.Server.Extensions;
using OnlineLibrary.Server.Models;
using OnlineLibrary.Server.Models.Entities;
using System.Security.Claims;

internal class Program
{
    private static void Main(string[] args)
    {
        var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: MyAllowSpecificOrigins,
                              policy =>
                              {
                                  policy.WithOrigins("http://example.com",
                                                      "http://www.contoso.com");
                              });
        });

        builder.Services.AddDbContext<AuthDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("UserConnection"));
        });

        // Add Authorization services
        builder.Services.AddAuthorization();

        // Generate Identity API endpoints
        builder.Services.AddIdentityApiEndpoints<IdentityUser>()
            .AddEntityFrameworkStores<AuthDbContext>();




        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen();
        // Add authentication database session connection
        





        // Add database connection
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddDbContext<UserDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("LibrarianConnection")));

        var app = builder.Build();

        app.MapIdentityApi<IdentityUser>();

        app.MapPost("/logout", async (SignInManager<IdentityUser> SignInManager) =>
        {
            await SignInManager.SignOutAsync();
            return Results.Ok();
        }).RequireAuthorization();

        app.MapGet("/pingauth", (ClaimsPrincipal user) =>
        {
            var email = user.FindFirstValue(ClaimTypes.Email);
            return Results.Json(new { Email = email });
        }).RequireAuthorization();

        app.MapPost("/registerlibrarian", (AddLibrarianDto addLibrarianDto) =>
        {
            var librarianEntity = new LibrarianStatus()
            {
                Email = addLibrarianDto.Email,
                IsLibrarian = addLibrarianDto.IsLibrarian,
            };
            using var scope = app.Services.CreateScope();

            var userDbContext = scope.ServiceProvider.GetRequiredService<UserDbContext>();
            userDbContext.LibrarianStatuses.Add(librarianEntity);
            userDbContext.SaveChanges();
        });

        app.UseDefaultFiles();
        app.UseStaticFiles();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors(MyAllowSpecificOrigins);

        app.UseAuthorization();

        app.MapControllers();

        app.MapFallbackToFile("/index.html");

        //using (var scope = app.Services.CreateScope())
        //{
        //    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        //    var roles = new[] { "Librarian", "Member" };

        //    foreach (var role in roles)
        //    {
        //        if (!await roleManager.RoleExistsAsync(role))
        //        {
        //            await roleManager.CreateAsync(new IdentityRole(role));
        //        }
        //    }
        //}
        app.CreateBookDbIfNotExists();

        app.CreateLibrariansDbIfNotExists();

        app.Run();
    }
}