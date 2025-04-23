using System.Globalization;

namespace IntroASP.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public Menu(int id, string descrption)
        {
            Id = id;
            Description = descrption;
        }
    }
}
