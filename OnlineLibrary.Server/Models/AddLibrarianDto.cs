namespace OnlineLibrary.Server.Models
{
    public class AddLibrarianDto
    {
        public required string Email { get; set; }
        public bool IsLibrarian { get; set; }
    }
}
