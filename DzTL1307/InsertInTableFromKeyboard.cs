using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DzTL1307.Models;

namespace DzTL1307
{
    public  class InsertInTableFromKeyboard<T>
    {
        public  void GoDo( T model)
        {
            List<object> TempSaveProp = new List<object>();
            PropertyInfo[] myPropertyInfo;
            myPropertyInfo = model.GetType().GetProperties();
            foreach(var prop in myPropertyInfo )
            {
                if (prop.Name.ToLower().Trim() == "id") continue;
            link1:
                

                Console.WriteLine($"Введите {prop.Name}");
                string readKey = null;
                while(String.IsNullOrEmpty(readKey))
                {
                    readKey = Console.ReadLine();
                }    
                var converter = TypeDescriptor.GetConverter(prop.PropertyType);
                try
                {
                    model.GetType().GetProperty(prop.Name).SetValue(model, converter.ConvertFrom(readKey), null); 
                }
                catch
                {
                    Console.WriteLine(" Неверный формат ввода");
                    goto link1;
                }
               
                
            }
            
        }
    }
}
