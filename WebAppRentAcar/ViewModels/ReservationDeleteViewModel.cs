namespace WebAppRentAcar.ViewModels
{
    public class ReservationDeleteViewModel
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string CarName { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsApproved { get; set; }
    }
}
