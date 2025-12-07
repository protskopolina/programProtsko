
using System;
using System.Collections.Generic;
using System.IO;
namespace lb1._2
{ 
class Program
{
    static void Main()
    {
        FileList files = new FileList("firstFile.txt");
        string[] fileArray = files.GetFiles();

        if (fileArray.Length == 0)
            return;

        bool run = true;
        while (run)
        {
            Console.WriteLine("\nДоступні файли:");
            for (int i = 0; i < fileArray.Length; i++)
                Console.WriteLine($"{i + 1}. {fileArray[i]}");
            Console.WriteLine("0. Вихід");

            Console.Write("Виберіть номер файлу: ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int num) || num < 0 || num > fileArray.Length)
            {
                Console.WriteLine("Некоректний ввід!");
                continue;
            }

            if (num == 0)
            {
                run = false;
                break;
            }

            string selectedFile = fileArray[num - 1];
            Analyzer analyzer = new Analyzer(selectedFile);
            analyzer.Analyze();
            analyzer.Show();

            Console.Write("\nЗберегти статистику у файл? (y/n): ");
            string choice = Console.ReadLine();
            if (choice.Equals("y", StringComparison.OrdinalIgnoreCase))
                analyzer.Save();
        }

        Console.WriteLine("Програма завершила роботу.");
    }
}
}