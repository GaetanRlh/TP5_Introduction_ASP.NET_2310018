using IntroASP.DataAccessLayer.Factories;

namespace IntroASP.DataAccessLayer
{
    public class DAL
    {
        private MenuFactory? menuFactory = null;
        private ReservationFactory? reservationFactory = null;

        public static string? ConnectionString { get; set; }

        public MenuFactory MenuFactory
        {
            get
            {
                if (menuFactory == null)
                {
                    menuFactory = new MenuFactory();
                }
                return menuFactory;
            }
        }

        public ReservationFactory ReservationFactory
        {
            get
            {
                if (reservationFactory == null)
                {
                    reservationFactory = new ReservationFactory();
                }
                return reservationFactory;
            }
        }

    }
}
