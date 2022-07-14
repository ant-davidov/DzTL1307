using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DzTL1307.Repositories;
using DzTL1307.Models;

namespace DzTL1307.ShowInfo
{
    public  class InfoFromTable <T>where T : IModel
    {    
        public void General(IRepository<T> table,Type model)
        {  
            while (true)
            {
                int chouse = 0;
                Console.WriteLine(" 1 - GetAll \n 2 - GetById \n 3 - Insert \n 4 - Delete \n 5 - выход  ");
            link1:
                while (!Int32.TryParse(Console.ReadLine(), out chouse))
                {
                    Console.WriteLine("Ошибка формата.Введите снова.");
                }
                switch (chouse)
                {
                    case 1:
                        {
                            GetAll(table);
                            break;
                        }
                    case 2:
                        {
                            GetByid(table);
                            break;
                        }
                    case 3:
                        {
                            InsertInTable(table,model);
                            break;
                        }
                    case 4:
                        {
                            Delete(table);
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            Console.WriteLine(" 1 - работа с таблицами \n 2 - Пример с  group by \n 3 - Получение объекта из другой таблицы по определенному столбцу \n 4 - Выход");
                            return;
                            
                        }
                    default:
                        {
                            Console.WriteLine("Неверный ввод.Введите снова.");
                            goto link1;
                        }
                }
            }
        }
        private void GetAll(IRepository<T> table)
        {
            
            IReadOnlyList<T> listModel = table.GetAll();
            Console.WriteLine(listModel.Count);
            if (listModel.Count == 0)
            {
                Console.WriteLine("Записи не найдена");

            }
            else
            {
                foreach (var obj in listModel)
                {
                    Console.WriteLine(obj.ToString()); 
                }
            }
        }
        private void GetByid(IRepository<T> table)
        {
            Console.WriteLine("Введите id:");
            string Id = Console.ReadLine();
            int intId = 0;

            while (true)
            {
                if (Int32.TryParse(Id, out intId))
                {
                    var obj = table.GetById(intId);
                    if (obj == null)
                    {
                        Console.WriteLine("Запись не найдена");
                    }
                    else
                    {
                        
                        Console.WriteLine(obj.ToString());
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный ввод");
                }
            }
        }

        private void InsertInTable(IRepository<T> table,Type model)
        { 
            var insertInTable = new InsertInTableFromKeyboard<T>();
            var newModel = insertInTable.GoDo(model);
            table.Insert(newModel) ;
        }

        private void Delete(IRepository<T> table)
        {
            int id = 0;
            Console.WriteLine("Введите id:");
            while (!Int32.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Неверный ввод");
            }
            table.Delete(id);
        }

    }
}
