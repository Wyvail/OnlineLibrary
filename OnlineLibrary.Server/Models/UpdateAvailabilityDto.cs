namespace OnlineLibrary.Server.Models
{
    public class UpdateAvailabilityDto
    {
        public bool Available { get; set; }
        public required string CheckOutDate { get; set; }
        public required string ReturnDate { get; set; }
    }
}
