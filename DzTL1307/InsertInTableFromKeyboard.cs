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
        public T GoDo(Type model)
        {
            List<object> TempSaveProp = new List<object>();
            PropertyInfo[] myPropertyInfo;
            myPropertyInfo = model.GetProperties();
            object[] argsForNewModel = new object[myPropertyInfo.Length];

            for (int i=0;i<myPropertyInfo.Length;i++)
            {
                if (myPropertyInfo[i].Name.ToLower().Trim() == "id")
                {
                    argsForNewModel[i] = 0;
                    continue;
                }
            link1:
                Console.WriteLine($"Введите {myPropertyInfo[i].Name}");
                string readKey = null;
                while(String.IsNullOrEmpty(readKey))
                {
                    readKey = Console.ReadLine();
                }    
                var converter = TypeDescriptor.GetConverter(myPropertyInfo[i].PropertyType);
                try
                {
                    argsForNewModel[i] = converter.ConvertFrom(readKey);
                   //model.GetType().GetProperty(myPropertyInfo[i].Name).SetValue(model, converter.ConvertFrom(readKey), null); 
                }
                catch
                {
                    Console.WriteLine(" Неверный формат ввода");
                    goto link1;
                }
               
                
            }
            return (T)Activator.CreateInstance(typeof(T), argsForNewModel);

        }
    }
}
