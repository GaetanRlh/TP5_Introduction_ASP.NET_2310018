

namespace IntroASP.Areas.Admin.ViewModels
{
    public class ReservationDeleteVM
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Courriel { get; set; } = string.Empty;
        public int NombreDePersonnes { get; set; }
        public DateTime DateReservation { get; set; }
        public int MenuId { get; set; }
    }
}
