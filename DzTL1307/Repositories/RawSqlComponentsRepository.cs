using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DzTL1307.Models;

namespace DzTL1307.Repositories
{
    public class RawSqlComponentsRepository : AbstracrRepository<Сomponents>
    {
      

        public override void Insert(Сomponents сomponents)
        {
            using (SqlConnection con = new SqlConnection(DzTL1307.Properties.Resources.ConnectioonString))
            {
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("INSERT INTO Сomponents VALUES(@Price,@Model, @Type, @IdConfiguration)", con))
                    {
                        command.Parameters.Add(new SqlParameter(@"Price", сomponents.Price));
                        command.Parameters.Add(new SqlParameter(@"Model", сomponents.Model));
                        command.Parameters.Add(new SqlParameter(@"Type", сomponents.Type));
                        command.Parameters.Add(new SqlParameter(@"IdConfiguration", сomponents.IdConfiguration));
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

        protected override Сomponents CreateModel(SqlDataReader reader)
        {
            return new Сomponents(
                       Convert.ToInt32(reader["Id"]),
                       Convert.ToDecimal(reader["Price"]),
                       Convert.ToString(reader["Model"]),
                       Convert.ToString(reader["Type"]),
                       Convert.ToInt32(reader["IdConfiguration"])
                   );
        }
        protected override string GetSqlCommand(string NameOfMethod)
        {
            switch (NameOfMethod)
            {
                case "GetAll":
                    return "select [Id],[Price] ,[Model],[Type], [IdConfiguration] from [Сomponents]";
                   
                case "GetById":
                    return "select * from [Сomponents] where [Id] = @id"; ;
                   
                case "Delete":
                    return "delete [Сomponents] where [Id] = @id";
                   
                default:
                    throw new ArgumentNullException("No suitable command found for the method");
            }
        }
        public override void Update(Сomponents сomponents)
        {
            if (сomponents == null)
            {
                throw new ArgumentNullException(nameof(Сomponents));
            }

            using var connection = new SqlConnection(DzTL1307.Properties.Resources.ConnectioonString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "update [Сomponents] set [Price] = @price, [Model]=@model,[Type]=@type  where [Id] = @id";
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = сomponents.Id;
            sqlCommand.Parameters.Add("@price", SqlDbType.Decimal).Value = сomponents.Price;
            sqlCommand.Parameters.Add("@model", SqlDbType.NVarChar, 100).Value = сomponents.Model;
            sqlCommand.Parameters.Add("@type", SqlDbType.NVarChar, 100).Value = сomponents.Type;
            sqlCommand.ExecuteNonQuery();
        }
    }



}
