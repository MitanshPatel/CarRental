namespace CarRental.Models
{
    public class CarClass
    {
        public int Id { get; set; }
        public required string Make { get; set; }
        public required string Model { get; set; }
        public int Year { get; set; }
        public decimal PricePerDay { get; set; }
        public bool IsAvailable { get; set; }
    }
}
