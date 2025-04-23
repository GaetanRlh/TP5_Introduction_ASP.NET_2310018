using MySql.Data.MySqlClient;
using IntroASP.Models;

namespace IntroASP.DataAccessLayer.Factories
{
    public class MenuFactory
    {
        private Menu CreateFromReader(MySqlDataReader mySqlDataReader)
        {
            int id = (int)mySqlDataReader["Id"];
            string description = mySqlDataReader["Description"].ToString() ?? "";

            return new Menu(id, description);
        }

        public Menu CreateEmpty()
        {
            return new Menu(0, string.Empty);
        }

        public List<Menu> GetAllMenu()
        {
            List<Menu> menus = new List<Menu>();
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM tp5_menuchoices ORDER BY Id";

                mySqlDataReader = mySqlCmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    Menu menu = CreateFromReader(mySqlDataReader);
                    menus.Add(menu);
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return menus;
        }

        public Menu? GetMenuById(int id)
        {
            Menu? menus = null;
            MySqlConnection? mySqlCnn = null;
            MySqlDataReader? mySqlDataReader = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "SELECT * FROM tp5_menuchoices WHERE Id = @Id";
                mySqlCmd.Parameters.AddWithValue("@Id", id);

                mySqlDataReader = mySqlCmd.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    menus = CreateFromReader(mySqlDataReader);
                }
            }
            finally
            {
                mySqlDataReader?.Close();
                mySqlCnn?.Close();
            }

            return menus;
        }
        public void InsertMenu(string description)
        {
            MySqlConnection? mySqlCnn = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "INSERT INTO tp5_menuchoices (Description) VALUES (@Description)";
                mySqlCmd.Parameters.AddWithValue("@Description", description);

                mySqlCmd.ExecuteNonQuery();
            }
            finally
            {
                mySqlCnn?.Close();
            }
        }


        public void UpdateMenu(Menu menu)
        {
            MySqlConnection? mySqlCnn = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "UPDATE tp5_menuchoices SET Description = @Description WHERE Id = @Id";
                mySqlCmd.Parameters.AddWithValue("@Description", menu.Description);
                mySqlCmd.Parameters.AddWithValue("@Id", menu.Id);

                mySqlCmd.ExecuteNonQuery();
            }
            finally
            {
                mySqlCnn?.Close();
            }
        }

        public void DeleteMenu(int id)
        {
            MySqlConnection? mySqlCnn = null;

            try
            {
                mySqlCnn = new MySqlConnection(DAL.ConnectionString);
                mySqlCnn.Open();

                MySqlCommand mySqlCmd = mySqlCnn.CreateCommand();
                mySqlCmd.CommandText = "DELETE FROM tp5_menuchoices WHERE Id = @Id";
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
