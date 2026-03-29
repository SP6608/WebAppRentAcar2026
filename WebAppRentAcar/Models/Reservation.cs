using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppRentAcar.Data;

namespace WebAppRentAcar.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public bool IsApproved { get; set; }

        //Navigation One Reservation One Car Id User is string!
        public int CarId { get; set; }
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; } = null!;
        public string UserId { get; set; } = null!;
        [ForeignKey(nameof(UserId))]
        public AppUser User { get; set; } = null!;
    }
}
