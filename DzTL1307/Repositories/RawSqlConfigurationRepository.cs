using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DzTL1307.Models;
using System.Data.SqlClient;


namespace DzTL1307.Repositories
{
    public class RawSqlConfigurationRepository : AbstracrRepository<Configuration>
    {
        public override void Insert(Configuration configuration)
        {
            using (SqlConnection con = new SqlConnection(DzTL1307.Properties.Resources.ConnectioonString))
            {
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("INSERT INTO Сomponents VALUES(@Picker,@Description, @Type)", con))
                    {
                        command.Parameters.Add(new SqlParameter(@"Picker", configuration.Picker));
                        command.Parameters.Add(new SqlParameter(@"Description", configuration.Description));
                        command.Parameters.Add(new SqlParameter(@"Type", configuration.Type));
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

        protected override Configuration CreateModel(SqlDataReader reader)
        {
            return new Configuration(
                       Convert.ToInt32(reader["Id"]),
                       Convert.ToString(reader["Picker"]),
                       Convert.ToString(reader["Description"]),
                       Convert.ToString(reader["Type"])
                   );
        }
        protected override string GetSqlCommand(string NameOfMethod)
        {
            switch (NameOfMethod)
            {
                case "GetAll":
                    return "select * from [Configuration]";

                case "GetById":
                    return "select * from [Configuration] where [Id] = @id"; ;

                case "Delete":
                    return "delete [Configuration] where [Id] = @id";

                default:
                    throw new ArgumentNullException("No suitable command found for the method");
            }
        }
    }

}
