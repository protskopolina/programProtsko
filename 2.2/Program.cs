using System;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleApp2;

class Program
{
    static void Main(string[] args)
    {
        var phones = new List<Telefon>()
        {
            new Telefon { Nazva="iPhone 13", Vyrobnyk="Apple", Tsina=1000, DataVypusku=new DateTime(2021,9,24)},
            new Telefon { Nazva="Galaxy S22", Vyrobnyk="Samsung", Tsina=850, DataVypusku=new DateTime(2022,2,11)},
            new Telefon { Nazva="Xperia 5", Vyrobnyk="Sony", Tsina=700, DataVypusku=new DateTime(2020,10,1)},
            new Telefon { Nazva="Redmi 12", Vyrobnyk="Xiaomi", Tsina=300, DataVypusku=new DateTime(2023,5,12)},
            new Telefon { Nazva="Galaxy A32", Vyrobnyk="Samsung", Tsina=450, DataVypusku=new DateTime(2021,3,17)},
            new Telefon { Nazva="iPhone 11", Vyrobnyk="Apple", Tsina=600, DataVypusku=new DateTime(2019,9,20)},
        };

        Console.WriteLine("Кількість телефонів: " + phones.Count());
        Console.WriteLine("Кількість телефонів із ціною > 100: " + phones.Count(p => p.Tsina > 100));
        Console.WriteLine("Кількість телефонів із ціною від 400 до 700: " + phones.Count(p => p.Tsina >= 400 && p.Tsina <= 700));
        Console.WriteLine("Кількість телефонів Samsung: " + phones.Count(p => p.Vyrobnyk == "Samsung"));
        Console.WriteLine("Мінімальна ціна: " + phones.Min(p => p.Tsina));
        Console.WriteLine("Максимальна ціна: " + phones.Max(p => p.Tsina));
        Console.WriteLine("Найстаріший телефон: " + phones.OrderBy(p => p.DataVypusku).First().Nazva);
        Console.WriteLine("Найсвіжіший телефон: " + phones.OrderByDescending(p => p.DataVypusku).First().Nazva);
        Console.WriteLine("Середня ціна: " + phones.Average(p => p.Tsina));

        Console.WriteLine("\nП’ять найдорожчих телефонів:");
        foreach (var p in phones.OrderByDescending(p => p.Tsina).Take(5))
            Console.WriteLine(p.Nazva + " – " + p.Tsina);

        Console.WriteLine("\nП’ять найдешевших телефонів:");
        foreach (var p in phones.OrderBy(p => p.Tsina).Take(5))
            Console.WriteLine(p.Nazva + " – " + p.Tsina);

        Console.WriteLine("\nТри найстаріші телефони:");
        foreach (var p in phones.OrderBy(p => p.DataVypusku).Take(3))
            Console.WriteLine(p.Nazva + " (" + p.DataVypusku.Year + ")");

        Console.WriteLine("\nТри найновіші телефони:");
        foreach (var p in phones.OrderByDescending(p => p.DataVypusku).Take(3))
            Console.WriteLine(p.Nazva + " (" + p.DataVypusku.Year + ")");

        Console.WriteLine("\nКількість телефонів кожного виробника:");
        foreach (var group in phones.GroupBy(p => p.Vyrobnyk))
            Console.WriteLine($"{group.Key} – {group.Count()}");

        Console.WriteLine("\nКількість моделей телефонів:");
        foreach (var group in phones.GroupBy(p => p.Nazva))
            Console.WriteLine($"{group.Key} – {group.Count()}");

        Console.WriteLine("\nКількість телефонів за роками:");
        foreach (var group in phones.GroupBy(p => p.DataVypusku.Year))
            Console.WriteLine($"{group.Key} – {group.Count()}");
    }
}