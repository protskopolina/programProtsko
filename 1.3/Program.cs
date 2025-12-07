using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lb1._3;



    class Program
    {
        static void Main()
        {
            PrinterQueue printer = new PrinterQueue();

            while (true)
            {
                Console.WriteLine("\n--- Меню Принтера ---");
                Console.WriteLine("1. Додати завдання до черги");
                Console.WriteLine("2. Друкувати наступне завдання");
                Console.WriteLine("3. Показати чергу");
                Console.WriteLine("4. Показати статистику друку");
                Console.WriteLine("5. Зберегти статистику у файл");
                Console.WriteLine("0. Вихід");
                Console.Write("Вибір: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Користувач: "); string user = Console.ReadLine();
                        Console.Write("Документ: "); string doc = Console.ReadLine();
                        Console.Write("Пріоритет (1-високий, 2-середній, 3-низький): ");
                        int priority = int.TryParse(Console.ReadLine(), out int p) ? p : 3;
                        printer.AddJob(new PrintJob(user, doc, priority));
                        break;

                    case "2":
                        printer.PrintNext();
                        break;

                    case "3":
                        printer.ShowQueue();
                        break;

                    case "4":
                        printer.ShowHistory();
                        break;

                    case "5":
                        Console.Write("Назва файлу: ");
                        string file = Console.ReadLine();
                    printer.SaveHistoryToFile(file);
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Невірний вибір!");
                        break;
                }
            }
        }
    }
