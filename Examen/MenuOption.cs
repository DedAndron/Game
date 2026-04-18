using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examen
{
    enum MenuOption
    {
        GetAllDataAsync = 1,
        GetDataByIdAsync = 2,
        GetDataByTitleAsync = 3,
        GetDataByAuthorAsync = 4,
        GetDataByDateAsync = 5,
        AddArticleAsync = 6,
        DeleteArticleAsync = 7,
        UpdateArticleAsync = 8,
        Exit = 0
    }
    public class MenuOptionStart
    {
        public static async Task RunAsync()
        {
            Console.WriteLine("1. Get All Data");
            Console.WriteLine("2. Get Data By ID");
            Console.WriteLine("3. Get Data By Title");
            Console.WriteLine("4. Get Data By Author");
            Console.WriteLine("5. Get Data By Date");
            Console.WriteLine("6. Add Data");
            Console.WriteLine("7. Delete Data");
            Console.WriteLine("8. Update Data");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");
            while (true)
            {
                ServerService service = new ServerService();
                ShowMenu();
                if (!Enum.TryParse(Console.ReadLine(), out MenuOption choice))
                {
                    Console.WriteLine("Wrong Choice!");
                    continue;
                }
                if (choice == MenuOption.Exit)
                    break;

                switch (choice)
                {
                    case MenuOption.GetAllDataAsync:
                        await service.GetAllDataAsync();
                        break;
                    case MenuOption.GetDataByIdAsync:
                        await service.GetDataByIdAsync();
                        break;
                    case MenuOption.GetDataByTitleAsync:
                        await service.GetDataByTitleAsync();
                        break;
                    case MenuOption.GetDataByAuthorAsync:
                        await service.GetDataByAuthorAsync();
                        break;
                    case MenuOption.GetDataByDateAsync:
                        await service.GetDataByDateAsync();
                        break;
                    case MenuOption.AddArticleAsync:
                        await ServerService.AddArticleAsync();
                        break;
                    case MenuOption.DeleteArticleAsync:
                        await service.DeleteArticleAsync();
                        break;
                    case MenuOption.UpdateArticleAsync:
                        await service.UpdateArticleAsync();
                        break;
                    case MenuOption.Exit:
                        Console.WriteLine("Exiting...");
                        break;
                }
            }
        }
        public static void ShowMenu()
        {
            Console.WriteLine("\nMake Choice:");
            foreach (var value in Enum.GetValues(typeof(MenuOption)))
            {
                Console.WriteLine($"{(int)value} - {value}");
            }
        }
    }
}
