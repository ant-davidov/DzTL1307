using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzTL1307
{
    public static class Select
    {
        public static void SelectData()
        {
            using var connection = new SqlConnection(DzTL1307.Properties.Resources.ConnectioonString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "SELECT Configuration.Id ,Picker FROM Computer LEFT JOIN Configuration ON Computer.IdConfiguration = Configuration.Id";

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Console.Write((Convert.ToString(reader["id"]).PadRight(2)));
                Console.WriteLine(reader.GetString(1));
            }
        }
    }
}
