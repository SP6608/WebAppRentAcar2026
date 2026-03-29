using Microsoft.AspNetCore.Identity;
using WebAppRentAcar.Models;

namespace WebAppRentAcar.Data
{
    public class AppUser:IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string EGN { get; set; } = null!;
        //Navigation Property One AppUser Many Reservations
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
