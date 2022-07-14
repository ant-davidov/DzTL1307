// See https://aka.ms/new-console-template for more information
using DzTL1307;
using DzTL1307.Models;
using DzTL1307.Repositories;
using DzTL1307.ShowInfo;
using DzTL1307.СommandForUpdateModel;

int chouse = 0;

startProg:
Console.WriteLine(" 1 - работа с таблицами \n 2 - Пример с  group by \n 3 - Получение объекта из другой таблицы по определенному столбцу \n 4 - Выход");

while (true)
{
    while (!Int32.TryParse(Console.ReadLine(), out chouse))
    {
        Console.WriteLine("Ошибка формата.Введите снова.");
    }

    switch (chouse)
    {
        case 1:
            {
                int ch = 0;
                Console.WriteLine(" 1 - Таблица Computer \n 2 - Таблица Confiration \n 3 - Таблица Components \n 4 - выход ");
            link2:
                while (!Int32.TryParse(Console.ReadLine(), out ch))
                {
                    Console.WriteLine("Ошибка формата.Введите снова.");
                }
                switch (ch)
                {
                    case 1:
                        {
                            Console.Clear();
                            int chouse3 = 0;
                            Console.WriteLine(" таблица - Computer");
                            Console.WriteLine(" 1 - Обновить \n 2 - Остальные действия \n 3 - Выход ");
                            while (!Int32.TryParse(Console.ReadLine(), out chouse3))
                            {
                                Console.WriteLine("Ошибка формата.Введите снова.");
                            }
                            if (chouse3 == 1)
                            {
                                CommandForUpdateComputer.SqlUpdate(new RawSqlComputerRepository());
                            }
                            else if (chouse3 == 2)
                            {
                                var tempInfoFromTable = new InfoFromTable<Computer>();
                                tempInfoFromTable.General(new RawSqlComputerRepository(), typeof(Computer));
                            }
                            else if (chouse3 == 3)
                            {
                                Console.Clear();
                                Console.WriteLine(" 1 - работа с таблицами \n 2 - Пример с  group by \n 3 - Получение объекта из другой таблицы по определенному столбцу \n 4 - Выход");

                                break;

                            }
                            Console.Clear();
                            Console.WriteLine(" 1 - работа с таблицами \n 2 - Пример с  group by \n 3 - Получение объекта из другой таблицы по определенному столбцу \n 4 - Выход");

                            break;


                        }
                    case 2:
                        {
                            Console.Clear();
                            int chouse3 = 0;
                            Console.WriteLine(" таблица - Configuration");
                            Console.WriteLine(" 1 - Обновить \n 2 - Остальные действия \n 3 - Выход ");
                            while (!Int32.TryParse(Console.ReadLine(), out chouse3))
                            {
                                Console.WriteLine("Ошибка формата.Введите снова.");
                            }
                            if (chouse3 == 1)
                            {
                                CommandForUpdateConfiguration.SqlUpdate(new RawSqlConfigurationRepository());
                            }
                            else if (chouse3 == 2)
                            {
                                var tempInfoFromTable = new InfoFromTable<Configuration>();
                                tempInfoFromTable.General(new RawSqlConfigurationRepository(), typeof(Configuration));
                                break;
                            }
                            else if (chouse3 == 3)
                            {
                                Console.Clear();
                                Console.WriteLine(" 1 - работа с таблицами \n 2 - Пример с  group by \n 3 - Получение объекта из другой таблицы по определенному столбцу \n 4 - Выход");

                                break;
                            }

                            break;

                        }
                    case 3:
                        {

                            Console.Clear();
                            int chouse3 = 0;
                            Console.WriteLine(" таблица - Components");
                            Console.WriteLine(" 1 - Обновить \n 2 - Остальные действия \n 3 - Выход ");
                            while (!Int32.TryParse(Console.ReadLine(), out chouse3))
                            {
                                Console.WriteLine("Ошибка формата.Введите снова.");
                            }
                            if (chouse3 == 1)
                            {
                                CommandForUpdateComponents.SqlUpdate(new RawSqlComponentsRepository());
                            }
                            else if (chouse3 == 2)
                            {
                                var tempInfoFromTable = new InfoFromTable<DzTL1307.Models.Сomponents>();
                                tempInfoFromTable.General(new RawSqlComponentsRepository(), typeof(DzTL1307.Models.Сomponents));
                                break;
                            }
                            else if (chouse3 == 3)
                            {
                                Console.Clear();
                                Console.WriteLine(" 1 - работа с таблицами \n 2 - Пример с  group by \n 3 - Получение объекта из другой таблицы по определенному столбцу \n 4 - Выход");

                                break;
                            }

                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            goto startProg;

                        }
                    default:
                        {
                            Console.WriteLine("Неверный ввод.Введите снова.");
                            goto link2;
                        }
                }




                break;
            }
        case 2:
            Console.WriteLine("Вывод средней цены ");
            GroupBy.GetGroupBy();
            Console.WriteLine("Выполнено");
            break;
        case 3:
            Console.WriteLine("Имя сборщика по IdConfiguration из таблицы Computers");
            Select.SelectData();
            break;
        case 4:
            Environment.Exit(0);
            break;
        default:
            {
                Console.WriteLine("Неверный ввод");
                goto startProg;
            }



    }
}


