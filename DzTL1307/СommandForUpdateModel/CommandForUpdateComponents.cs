using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DzTL1307.Models;
using DzTL1307.Repositories;

namespace DzTL1307.СommandForUpdateModel
{
    public static class CommandForUpdateComponents
    {
        public static void SqlUpdate(RawSqlComponentsRepository componentsRepository)
        {

            Console.WriteLine("Введите Id:");
            int id;
            while (!Int32.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Ошибка формата.Введите снова.");
            }
            var components = componentsRepository.GetById(id);
            if (components == null)
            {
                Console.WriteLine("Запись не найдена");
                Console.ReadKey();
                Console.WriteLine(" 1 - работа с таблицами \n 2 - Пример с  group by \n 3 - Получение объекта из другой таблицы по определенному столбцу \n 4 - Выход");

                return;
            }
            Console.WriteLine("Введите цену");
            decimal price;
            while (!Decimal.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Ошибка формата.Введите снова.");
            }

            Console.WriteLine("Введите модель");
            string newModel = null;
            while (String.IsNullOrEmpty(newModel))
            {
                newModel = Console.ReadLine();
            }

            Console.WriteLine("Введите тип");
            string type = null;
            while (String.IsNullOrEmpty(type))
            {
                type = Console.ReadLine();
            }

            components.Update(price, newModel, type);
            componentsRepository.Update(components);
            Console.WriteLine("Обновлен");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(" 1 - работа с таблицами \n 2 - Пример с  group by \n 3 - Получение объекта из другой таблицы по определенному столбцу \n 4 - Выход");

        }
    }
}
