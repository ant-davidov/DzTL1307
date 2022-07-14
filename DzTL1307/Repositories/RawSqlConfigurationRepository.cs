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
    public class RawSqlConfigurationRepository : AbstracrRepository<Configuration>
    {
        public override void Insert(Configuration configuration)
        {
            using (SqlConnection con = new SqlConnection(DzTL1307.Properties.Resources.ConnectioonString))
            {
                con.Open();
                
                    using (SqlCommand command = new SqlCommand("INSERT INTO Configuration VALUES(@Picker,@Description, @Type)", con))
                    {
                        command.Parameters.Add(new SqlParameter(@"Picker", configuration.Picker));
                        command.Parameters.Add(new SqlParameter(@"Description", configuration.Description));
                        command.Parameters.Add(new SqlParameter(@"Type", configuration.Type));
                        command.ExecuteNonQuery();
                        Console.WriteLine(" Запись добавлена ");
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
        public override void Update(Configuration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(Сomponents));
            }
            using var connection = new SqlConnection(DzTL1307.Properties.Resources.ConnectioonString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "update [Configuration] set [Picker] = @picker, [Description]=@description,[Type]=@type  where [Id] = @id";
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = configuration.Id;
            sqlCommand.Parameters.Add("@picker", SqlDbType.NVarChar, 100).Value = configuration.Picker;
            sqlCommand.Parameters.Add("@description", SqlDbType.NVarChar, 1000).Value = configuration.Description;
            sqlCommand.Parameters.Add("@type", SqlDbType.NVarChar, 100).Value = configuration.Type;
            sqlCommand.ExecuteNonQuery();
        }
    }

}
