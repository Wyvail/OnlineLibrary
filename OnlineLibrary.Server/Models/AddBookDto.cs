namespace OnlineLibrary.Server.Models
{
    public class AddBookDto
    {
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required string Description { get; set; }
        public int ImageId { get; set; }
        public required string Publisher { get; set; }
        public DateTime PublishDate { get; set; }
        public required string Category { get; set; }
        public int ISBN { get; set; }
        public int PageCount { get; set; }
        public bool Available { get; set; }
    }
}
