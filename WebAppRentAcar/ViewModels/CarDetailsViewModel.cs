using System.ComponentModel.DataAnnotations;

namespace WebAppRentAcar.ViewModels
{
    public class CarDetailsViewModel
    {
        public int Id { get; set; }
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; }
        public int Passengers { get; set; }
        public string? Description { get; set; }
        [Display(Name = "Price per day")]
        public decimal PricePerDay { get; set; }
    }
}
