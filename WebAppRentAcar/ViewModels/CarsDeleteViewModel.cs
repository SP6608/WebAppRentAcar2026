namespace WebAppRentAcar.ViewModels
{
    public class CarsDeleteViewModel
    {
        public int Id { get; set; }
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; }
        public int Passengers { get; set; }
        public decimal PricePerDay { get; set; }
        public string? Description { get; set; }
    }
}
