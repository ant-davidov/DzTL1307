using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzTL1307.Models
{
    public class Configuration: IModel
    {
        public int Id { get;private set; }
        public string Picker { get;private set; }

        public string Description { get;private set; }

        public string Type { get;private set; }

        public Configuration (int id, string picker, string description, string type)
        {
            Id = id;
            Picker = picker;
            Description = description;
            Type = type;
        }
    }
}
