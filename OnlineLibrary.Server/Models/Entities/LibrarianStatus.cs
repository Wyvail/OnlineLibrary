namespace OnlineLibrary.Server.Models.Entities
{
    public class LibrarianStatus
    {
        public Guid Id { get; set; }
        public required string Email { get; set; }
        public bool IsLibrarian { get; set; }
    }
}
