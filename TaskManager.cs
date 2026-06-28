using MySql.Data.MySqlClient;

namespace CyberSecurityBot
{

    public class TaskManager
    {
        private string connectionString = "server=localhost;database=CyberSecurityDB;uid=root;pwd=Kj@526423;";

        public void AddTask(string title, string description)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO Tasks" +
                    "(Title, Description) VALUES(@title,@description)";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@description", description);

                cmd.ExecuteNonQuery();
            }
        }

        public bool CompleteTask(int taskId)
        {
            using(MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "Update Tasks SET Completed = TRUE WHERE TaskedID = @id";

                MySqlCommand cmd
                     = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", taskId);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
