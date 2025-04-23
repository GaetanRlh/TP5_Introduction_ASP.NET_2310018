using MySql.Data.MySqlClient;
using IntroASP.Models;

namespace IntroASP.DataAccessLayer.Factories
{
    public class ReservationFactory
    {
        private  Reservation CreateFromReader(MySqlDataReader mySqlDataReader)
        {
            int id = (int)mySqlDataReader["Id"];
            string name = mySqlDataReader["Nom"].ToString() ?? string.Empty;
            string email = mySqlDataReader["Courriel"].ToString() ?? string.Empty;
            int numberOfPeople = (int)mySqlDataReader["NbPersonne"];
            DateTime reservationDate = DateTime.Parse(mySqlDataReader["DateReservation"].ToString() ?? string.Empty);
            int menuChoiceId = (int)mySqlDataReader["MenuChoiceId"];

            return new Reservation(id, name, email,numberOfPeople,reservationDate,menuChoiceId);
        }

        public Reservation CreateEmpty()
        {
            return new Reservation(0, string.Empty, string.Empty,0,DateTime.Now,0);
        }

        public List<Reservation> GetAllReservations()
        {
            List<Reservation> reservations = new List<Reservation>();
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM tp5_reservations ORDER BY Nom";

                mySqlDataReader = mySqlCmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    Reservation category = CreateFromReader(mySqlDataReader);
                    reservations.Add(category);
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return reservations;
        }

        public Reservation? GetReservationById(int id)
        {
            Reservation? reservation = null;
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;
            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();
                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM tp5_reservations WHERE Id = @Id";
                mySqlCmd.Parameters.AddWithValue("@Id", id);
                mySqlDataReader = mySqlCmd.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    reservation = CreateFromReader(mySqlDataReader);
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }
            return reservation;
        }

        public int InsertReservation(Reservation rn)
        {
            int newId = 0;
            MySqlConnection? mySqlCnn = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = @"
            INSERT INTO tp5_reservations (Nom, Courriel, NbPersonne, DateReservation, MenuChoiceId)
            VALUES (@Nom, @Courriel, @NbPersonne, @DateReservation, @MenuChoiceId);
            SELECT LAST_INSERT_ID();";

                mySqlCmd.Parameters.AddWithValue("@Nom", rn.Name);
                mySqlCmd.Parameters.AddWithValue("@Courriel", rn.Email);
                mySqlCmd.Parameters.AddWithValue("@NbPersonne", rn.NumberOfPeople);
                mySqlCmd.Parameters.AddWithValue("@DateReservation", rn.ReservationDate);
                mySqlCmd.Parameters.AddWithValue("@MenuChoiceId", rn.MenuChoiceId);

                newId = Convert.ToInt32(mySqlCmd.ExecuteScalar());
            }
            finally
            {
                mySqlCnn?.Close();
            }

            return newId;
        }

        public void DeleteReservation(int id)
        {
            MySqlConnection? mySqlCnn = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "DELETE FROM tp5_reservations WHERE Id = @Id";
                mySqlCmd.Parameters.AddWithValue("@Id", id);

                mySqlCmd.ExecuteNonQuery();
            }
            finally
            {
                mySqlCnn?.Close();
            }
        }

    }
}
