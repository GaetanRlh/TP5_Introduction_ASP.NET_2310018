namespace IntroASP.ViewModels
{
    public class ReservationDetailsVM
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int NumberOfPeople { get; set; }
        public DateTime ReservationDate { get; set; }
        public string MenuDescription { get; set; } = string.Empty;
    }
}
