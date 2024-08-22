Online Library using ASP.NET Core and React.JS

For my application, I learned ASP.NET Core and how to integrate it with React.JS.  
I used EntityFramework Core as my ORM and ASP.NET Identity to manage login/registration.  
To manage the database, I used a SQLServer Express server.  
Since this is my first time building an application in .NET, I am not sure about the default installations after downloading a solution, so I will list all of the packages I have installed to ensure the environment is the same.

Setup:
__________________________
1. Download the code and open in Visual Studio 2022
2. Install the following packages:  
  a. Microsoft.EntityFrameworkCore.Tools  
  b. Microsoft.EntityFrameworkCore.SqlServer  
  c. Microsoft.EntityFrameworkCore.Design  
  d. Microsoft.EntityFrameworkCore.InMemory  
  e. Microsoft.AspNetCore.Identity.UI  
  f. Microsoft.AspNetCore.SpaProxy  
  g. Microsoft.AspNetCore.Identity.EntityFrameworkCore  
  h. EFCore.AutomaticMigrations  
3. Configure the appsettings.json connection strings:  
  a. Replace the server name with your own server instance  
4. Create the Identity User Databases:  
  a. Open the Package Manager Console and run ```add-migration Initial-Migration -Context AuthDbContext```  
  b. Run ```update-database -Context AuthDbContext```
5. Start project and client
6. A default librarian account is provided as ```admin@admin.net```  
   a. To use this account, register the above email as a user to be able to login to the website.

Usage:
__________________________________
As a regular member:  
* Click on any book to view expanded details.
* Check out a book by clicking the button.
* Search for and sort books by title, author, or availability.
* Logout once done at the top.

As a librarian:
* Click on any book to view expanded details.
* If the book is checked out, a mark as returned button is provided to check it in.
* Three forms are available at the bottom to add a book, change a book's details, or delete a book from the database.

Work Needed:
______________________________________
* Automatically populate the update book form with the selected book
* Add styling
* Add proper filters (includes and excludes)
* Return password errors properly
* Cleanup registration page
* Fix ISBN numbers in seed function
* Make expanded view expand from under table row
