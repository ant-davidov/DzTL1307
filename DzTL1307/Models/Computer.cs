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
        public void Update (string owner, decimal totalPrice)
        {
            Owner = owner;
            TotalPrice = totalPrice;
        }
        
        public override string ToString()
        {
            return GetType().GetProperties()
                .Select(info => (info.Name, Value: info.GetValue(this, null) ?? "(null)"))
                .Aggregate(
                    new StringBuilder(),
                    (sb, pair) => sb.AppendLine($"{pair.Name}: {pair.Value}"),
                    sb => sb.ToString());
        }

    }
}
