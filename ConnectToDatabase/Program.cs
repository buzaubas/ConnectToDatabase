using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

namespace ConnectToDatabase
{
    internal class Program
    {
        const string connectionString = "Server=223-10;Database=Market;Trusted_Connection=true;Encrypt=false";
        const string connectionStringStudents = "Server=223-10;Database=Scores;Trusted_Connection=true;Encrypt=false";
        static void Main(string[] args)
        {

            try
            {
                showTotalPrice();
                //const string sqlQuery = "SELECT * FROM dbo.MyInventory";
                //using var sqlConnection = new SqlConnection(connectionString);
                //sqlConnection.Open();

                //using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                //using var reader = sqlCommand.ExecuteReader();
                //while (reader.Read())
                //{
                //    var name = reader["name"].ToString();
                //    var price = reader["price"].ToString();
                //    var quantity = reader["quantity"].ToString();
                //    Console.WriteLine($"name - {name}, price - {price}, quantity - {quantity}");
                //    //int fullprice = Convert.ToInt32(price) * Convert.ToInt32(quantity);
                //    Console.WriteLine("Overall: " + getOverallPrice(Convert.ToInt32(price), Convert.ToInt32(quantity)));
                //}
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            
            
        }

        public static int getOverallPrice(string connectionString)
        {

            //return price*quantity;

            const string sqlQuery = "SELECT * FROM dbo.MyInventory";
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            using var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                var name = reader["name"].ToString();
                var price = reader["price"];
                var quantity = reader["quantity"];


                Console.WriteLine($"name - {name}, price - {price}, quantity - {quantity}");
                //int fullprice = Convert.ToInt32(price) * Convert.ToInt32(quantity);
                int overall = Convert.ToInt32(price) * Convert.ToInt32(quantity);
                Console.WriteLine("Overall: " + overall);

            }
            return 0;
        }

        private static void showTotalPrice()
        {

            //return price*quantity;

            const string sqlQuery = "SELECT * FROM dbo.MyInventory";

            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            using var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                var name = reader["name"].ToString();
                var price = reader.GetInt32(i: 1);
                var quantity = reader.GetInt32(i:2);

                var totalPrice = price * quantity;
                Console.WriteLine($"name - {name}, totalprice - {totalPrice}");

            }
        }

        private static void isConnectedToDatabase()
        {
            const string sqlQuery = "SELECT * FROM dbo.StudentScores";

            using var sqlConnection = new SqlConnection(connectionStringStudents);
            sqlConnection.Open();

            

            
        }

    }
}