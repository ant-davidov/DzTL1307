using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DzTL1307.Models;

namespace DzTL1307.Repositories
{

    public abstract class AbstracrRepository<T> : IRepository<T> where T : IModel
    { 
     
        protected abstract T CreateModel(SqlDataReader reader);
        protected abstract string GetSqlCommand(string NameOfMethod);


        public IReadOnlyList<T> GetAll()
        {

            var result = new List<T>();

            using var connection = new SqlConnection(DzTL1307.Properties.Resources.ConnectioonString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = GetSqlCommand(System.Reflection.MethodBase.GetCurrentMethod().Name);

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add(CreateModel(reader));
            }

            return result;
        }
        public T GetById(int id)
        {
            using var connection = new SqlConnection(DzTL1307.Properties.Resources.ConnectioonString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = GetSqlCommand(System.Reflection.MethodBase.GetCurrentMethod().Name);
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                return CreateModel(reader);
            }
            else
            {
                return default(T);
            }
        }
        public void Delete(int id)
        {
            using var connection = new SqlConnection(DzTL1307.Properties.Resources.ConnectioonString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = GetSqlCommand(System.Reflection.MethodBase.GetCurrentMethod().Name);
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
            sqlCommand.ExecuteNonQuery();
            
           
        }
        public abstract void Insert(T model);
       
    }
}
