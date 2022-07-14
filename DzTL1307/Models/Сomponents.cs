using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzTL1307.Models
{
    public class Сomponents : IModel
    {
        public int Id { get;private set; }
        public decimal Price { get;private set; }
        public string Model { get;private set; }
        
        public string Type { get;private set; }
        public int IdConfiguration { get; private set; }

        public Сomponents (int id, decimal price,string model, string type, int idConfiguration)
        {
            Id = id;
            Price = price;
            Model = model;
            Type = type;
            IdConfiguration = idConfiguration;
           
        }
        
        public void Update(decimal price, string model, string type)
        {
            Price = price;
            Model = model;
            Type = type;
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
