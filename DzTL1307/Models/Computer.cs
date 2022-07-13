using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DzTL1307.Models
{
    public class Computer: IModel
    {
        
        public int Id { get; private set; }
        public string Owner { get; private set; }
        public decimal TotalPrice { get; private set; }
        public int IdConfiguration { get; private set; }
       public Computer(int id, string owner,decimal totalPrice, int idConfiguration)
        {
            Id = id;
            Owner = owner;
            TotalPrice = totalPrice;
            IdConfiguration = idConfiguration;
        }

    }
}
