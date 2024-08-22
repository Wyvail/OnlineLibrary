namespace OnlineLibrary.Server.Models
{
    public class AddBookDto
    {
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required string Description { get; set; }
        public int ImageId { get; set; }
        public required string Publisher { get; set; }
        public required string PublishDate { get; set; }
        public required string Category { get; set; }
        public int ISBN { get; set; }
        public int PageCount { get; set; }
        public bool Available { get; set; }
        public required string CheckOutDate { get; set; }
        public required string ReturnDate { get; set; }
    }
}
