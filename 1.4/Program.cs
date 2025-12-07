using LB1._44;
using System;
using System.Collections;
using DictionaryEntry = LB1._44.DictionaryEntry;

class Program
{
   
    static void Main()
    {
        DictionaryLang dict = new DictionaryLang();

        while (true)
        {
            Console.WriteLine("\n1.Додати слово  2.Перекласти  3.Показати всі слова  0.Вихід");
            Console.Write("Вибір: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Слово англійською: ");
                    string eng = Console.ReadLine();
                    Console.Write("Переклад українською: ");
                    string ukr = Console.ReadLine();
                    dict.AddEntry(eng, ukr);
                    Console.WriteLine("Слово додано.");
                    break;

                case "2":
                    Console.Write("Слово для перекладу: ");
                    string word = Console.ReadLine();
                    Console.WriteLine(dict.Translate(word));
                    break;

                case "3":
                    dict.ShowAll();
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
