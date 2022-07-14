using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DzTL1307.Models;
using System.Data.SqlClient;
using System.Data;

namespace DzTL1307.Repositories
{
    public class RawSqlComputerRepository: AbstracrRepository<Computer>
    {
        public override void Insert(Computer computer)
        {
            using (SqlConnection con = new SqlConnection(DzTL1307.Properties.Resources.ConnectioonString))
            {
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("INSERT INTO Computer VALUES(@Owner,@TotalPrice, @IdConfiguration)", con))
                    {
                        command.Parameters.Add(new SqlParameter(@"Owner", computer.Owner));
                        command.Parameters.Add(new SqlParameter(@"TotalPrice", computer.TotalPrice));
                        command.Parameters.Add(new SqlParameter(@"IdConfiguration", computer.IdConfiguration));
                        command.ExecuteNonQuery();
                        Console.WriteLine(" Запись добавлена ");
                    }
                }
                catch
                {
                    Console.WriteLine("Не удалось. Проверьте существование записи в таблице Configuration с введенным IdConfiguration");
                }
            }
        }

        protected override Computer CreateModel(SqlDataReader reader)
        {
            return new Computer(
                       Convert.ToInt32(reader["Id"]),
                       Convert.ToString(reader["Owner"]),
                       Convert.ToDecimal(reader["TotalPrice"]),
                       Convert.ToInt32(reader["IdConfiguration"])
                   );
        }
        protected override string GetSqlCommand(string NameOfMethod)
        {
            switch (NameOfMethod)
            {
                case "GetAll":
                    return "select * from [Computer]";

                case "GetById":
                    return "select * from [Computer] where [Id] = @id"; ;

                case "Delete":
                    return "delete [Computer] where [Id] = @id";

                default:
                    throw new ArgumentNullException("No suitable command found for the method");
            }
        }
        public override void Update(Computer computer)
        {
            if (computer == null)
            {
                throw new ArgumentNullException(nameof(Computer));
            }

            using var connection = new SqlConnection(DzTL1307.Properties.Resources.ConnectioonString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "update [Computer] set [Owner] = @owner, [TotalPrice]=@totalprice  where [Id] = @id";
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = computer.Id;
            sqlCommand.Parameters.Add("@owner", SqlDbType.NVarChar, 100).Value = computer.Owner;
            sqlCommand.Parameters.Add("@totalprice", SqlDbType.NVarChar, 100).Value = computer.TotalPrice;
            sqlCommand.ExecuteNonQuery();
        }
    }

}

