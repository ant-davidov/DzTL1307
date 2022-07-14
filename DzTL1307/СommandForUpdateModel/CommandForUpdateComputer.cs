using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DzTL1307.Models;
using DzTL1307.Repositories;

namespace DzTL1307.СommandForUpdateModel
{
    public static class CommandForUpdateComputer
    {
         public static void SqlUpdate(RawSqlComputerRepository computerRepository)
        {
           
            Console.WriteLine("Введите Id:");
            int id;
            while (!Int32.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Ошибка формата.Введите снова.");
            }
            var computer = computerRepository.GetById(id);
            if (computer == null)
            {
                Console.WriteLine("Запись не найдена");
                Console.ReadKey();
                Console.WriteLine(" 1 - работа с таблицами \n 2 - Пример с  group by \n 3 - Получение объекта из другой таблицы по определенному столбцу \n 4 - Выход");

                return;
            }
            Console.WriteLine("Введите новое имя");
            string newName = Console.ReadLine();

            Console.WriteLine("Введите новую цену");
            decimal price;
            while (!Decimal.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Ошибка формата.Введите снова.");
            }
            computer.Update(newName, price);

            computerRepository.Update(computer);
            Console.WriteLine("Обновлен");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(" 1 - работа с таблицами \n 2 - Пример с  group by \n 3 - Получение объекта из другой таблицы по определенному столбцу \n 4 - Выход");

        }
    }
}
