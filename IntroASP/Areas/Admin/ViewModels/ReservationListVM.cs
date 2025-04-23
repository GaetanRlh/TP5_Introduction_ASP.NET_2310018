using IntroASP.Models;

namespace IntroASP.Areas.Admin.ViewModels
{
    public class ReservationListVM
    {
        public IEnumerable<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
