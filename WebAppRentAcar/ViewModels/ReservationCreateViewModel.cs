using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebAppRentAcar.ViewModels
{
    public class ReservationCreateViewModel
    {
        [Required]
        [Display(Name = "Car")]
        public int CarId { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public IEnumerable<SelectListItem> Cars { get; set; } = new List<SelectListItem>();
    }
}