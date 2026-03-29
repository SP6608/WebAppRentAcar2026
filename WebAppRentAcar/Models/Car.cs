using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppRentAcar.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Brand { get; set; } = null!;
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Model { get; set; } = null!;
        [Range(1950, 2080)]
        public int Year { get; set; }
        [Required]
        [Range(1,6)]
        public int Passengers { get; set; }
        [MaxLength(4048)]
        public string? Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Range(1,500)]
        public decimal PricePerDay { get; set; }
    }
}
