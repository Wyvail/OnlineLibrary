namespace OnlineLibrary.Server.Models.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required string Description { get; set; }
        public int ImageId { get; set; }
        public required string Publisher { get; set; }
        public DateOnly PublishDate { get; set; }
        public required string Category { get; set; }
        public int ISBN { get; set; }
        public int PageCount { get; set; }
        public bool Available { get; set; }
        public DateOnly? CheckOutDate { get; set; }
        public DateOnly? ReturnDate { get; set; }

    }
}
