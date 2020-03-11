using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace WMDRegisterDemo.src
{
    class Database
    {
        public MySqlConnection connection;

        public Database()
        {
            string host = "localhost";
            string db = "register";
            string port = "3306";
            string user = "root";
            string pass = "";

            string dbconfig = "datasource = "+host+"; database = "+db+"; port = "+port+"; username = "+user+"; password = "+pass+"; SslMode = none";

            connection = new MySqlConnection(dbconfig);
        }
    }

    class Crud:Database
    {
        // Properties
        public string name { set; get; }
        public string cnpj { set; get; }
        public int id { set; get; }

        // Read Properties

        public DataTable dataTable = new DataTable();
        private DataSet dataSet = new DataSet();

        // Insert Method

        public void InsertData()
        {
            connection.Open();
            using (MySqlCommand command = new MySqlCommand())
            {
                command.CommandText = "INSERT INTO `clients`(`id`, `name`, `cnpj`) VALUES (DEFAULT, @name, @cnpj)";
                command.CommandType = CommandType.Text;
                command.Connection = connection;

                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                command.Parameters.Add("@cnpj", MySqlDbType.VarChar).Value = cnpj;

                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        // Update Method

        public void UpdateData()
        {
            connection.Open();
            using (MySqlCommand command = new MySqlCommand())
            {
                command.CommandText = "UPDATE `clients` SET `name` = @name, `cnpj` = @cnpj WHERE id = @id";
                command.CommandType = CommandType.Text;
                command.Connection = connection;

                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                command.Parameters.Add("@cnpj", MySqlDbType.VarChar).Value = cnpj;
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        // Delete Method

        public void DeleteData()
        {
            connection.Open();
            using (MySqlCommand command = new MySqlCommand())
            {
                command.CommandText = "DELETE FROM `clients` WHERE id = @id";
                command.CommandType = CommandType.Text;
                command.Connection = connection;

                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        // Read Method

        public void ReadData()
        {
            dataTable.Clear();
            string query = "SELECT * FROM `clients`";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
            dataAdapter.Fill(dataSet);
            dataTable = dataSet.Tables[0];
        }
    }
}
