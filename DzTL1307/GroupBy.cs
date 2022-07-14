using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DzTL1307
{
    public static class GroupBy
    {
        public static void GetGroupBy()
        {
            using var connection = new SqlConnection(DzTL1307.Properties.Resources.ConnectioonString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "SELECT [Type], AVG(price) as avg FROM Сomponents GROUP BY [Type]";

            using SqlDataReader reader = sqlCommand.ExecuteReader();
           while (reader.Read())
            {
                Console.Write(reader.GetString(0).PadRight(15));
                Console.WriteLine(Convert.ToString(reader["avg"]));
            }
            
        }
    }
}
