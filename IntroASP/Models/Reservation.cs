namespace IntroASP.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime ReservationDate { get; set; }
        public int MenuChoiceId { get; set; }
        public Reservation(int id, string name, string email, int numberOfPeople, DateTime reservationDate, int menuChoiceId)
        {
            Id = id;
            Name = name;
            Email = email;
            NumberOfPeople = numberOfPeople;
            ReservationDate = reservationDate;
            MenuChoiceId = menuChoiceId;
        }
    }
}
