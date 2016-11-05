using MySql.Data.MySqlClient;
using System;

namespace CarsFactory.Utilities
{
    public class MySQLConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public MySQLConnect()
        {
            Initialize();
        }

        //Initialize database
        private void Initialize()
        {
            server = "localhost";
            database = "cars_factory_json_reports";
            uid = "root";
            password = "vremennaparola";

            // Open connection to MySQL server to create db if there is none
            string connStr = $"server={server};user={uid};port=3306;password={password};";
            MySqlConnection conn = new MySqlConnection(connStr);
            MySqlCommand cmd;
            string s0;

            try
            {
                conn.Open();
                s0 = $"CREATE DATABASE IF NOT EXISTS `{database}`;"// Create the database with table and columns                   
                    + $"CREATE TABLE IF NOT EXISTS `{database}`.`reports` (`id` INT NOT NULL AUTO_INCREMENT, `report` JSON NOT NULL, PRIMARY KEY (`id`));";
                cmd = new MySqlCommand(s0, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "password=" + password + ";";
            // create a new connection to the database with name etc. that we will use in all methods
            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void Insert(object dataToInsert)
        {

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO reports (report) VALUES(?report)";
                cmd.Parameters.Add("?report", MySqlDbType.JSON).Value = dataToInsert;

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
    }
}
