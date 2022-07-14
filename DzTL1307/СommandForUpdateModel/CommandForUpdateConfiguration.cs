using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DzTL1307.Models;
using DzTL1307.Repositories;
namespace DzTL1307.СommandForUpdateModel
{
    public static class CommandForUpdateConfiguration
    {
        public static void SqlUpdate(RawSqlConfigurationRepository configurationRepository)
        {

            Console.WriteLine("Введите Id:");
            int id;
            while (!Int32.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Ошибка формата.Введите снова.");
            }
            var configuration = configurationRepository.GetById(id);
            if (configuration == null)
            {
                Console.WriteLine("Запись не найдена");
                Console.ReadKey();
                Console.WriteLine(" 1 - работа с таблицами \n 2 - Пример с  group by \n 3 - Получение объекта из другой таблицы по определенному столбцу \n 4 - Выход");

                return;
            }
            Console.WriteLine("Введите имя сборщика");
            string newName = null;
            while (String.IsNullOrEmpty(newName))
            {
                newName = Console.ReadLine();
            }

            Console.WriteLine("Введите описание");
            string newDescr = null;
            while (String.IsNullOrEmpty(newDescr))
            {
                newDescr = Console.ReadLine();
            }

            Console.WriteLine("Введите тип");
            string type = null;
            while (String.IsNullOrEmpty(type))
            {
                type = Console.ReadLine();
            }

            configuration.Update(newName,newDescr,type);
            configurationRepository.Update(configuration);
            Console.WriteLine("Обновлен");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(" 1 - работа с таблицами \n 2 - Пример с  group by \n 3 - Получение объекта из другой таблицы по определенному столбцу \n 4 - Выход");

        }
    }
}
