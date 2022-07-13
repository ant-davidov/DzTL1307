// See https://aka.ms/new-console-template for more information
using DzTL1307;
using DzTL1307.Models;
using DzTL1307.Repositories;

Console.WriteLine("Hello, World!");

while (true)
{
    Console.WriteLine("Введите команду:");
    string command = Console.ReadLine();

    RawSqlComponentsRepository ComponentsRepository = new RawSqlComponentsRepository();

    if (command == "get-сomponents")
    {
        IReadOnlyList<Сomponents> сomponents = ComponentsRepository.GetAll() ;
        if (сomponents.Count == 0)
        {
            Console.WriteLine("Записи не найдена");
            continue;
        }

        foreach (Сomponents author in сomponents)
        {
            Console.WriteLine($"Id: {author.Id}, Model: {author.Model}");
        }
    }
    else if (command == "get-сomponents-by-id")
    {
        Console.WriteLine("Введите id:");
        string Id = Console.ReadLine();
        int intId = 0;


        if (Int32.TryParse(Id, out intId))
        {
            var companent = ComponentsRepository.GetById(intId);
            if (companent == null)
            {
                Console.WriteLine("Запись не найдена");
            }
            else
            {
                Console.WriteLine(companent.ToString());
            }
        }
        else
        {
            Console.WriteLine("Неверный ввод");
        }

    }
    else if (command=="get-сomponents-insert")
    {
        var forInsert = new Сomponents(0, 0, "0", "0", 1);
        var insertInTable = new InsertInTableFromKeyboard<Сomponents>();
        insertInTable.GoDo(forInsert);
        ComponentsRepository.Insert(forInsert);
    }
    else if (command == "get-сomponents-delete")
    {
        int id = 0;
        Console.WriteLine("Введите id:");
        while (!Int32.TryParse(Console.ReadLine() ,out id))
        {
            Console.WriteLine("Неверный ввод");
        }
        ComponentsRepository.Delete(id);
    }



}
