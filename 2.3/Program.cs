using System;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleApp3;

class President : Employer { }
class Manager : Employer { }
class Worker : Employer { }



class Program
{
    static void Main(string[] args)
    {
        // Створюємо компанію
        var company = new Company()
        {
            Name = "TechVision",
            President = new President { Name = "Ivan Petrov", Profession = "President", Education = "вища", BirthDate = new DateTime(1975, 5, 12), Experience = 25, Salary = 30000 }
        };

        // Створюємо список працівників
        company.Employers = new List<Employer>()
        {
            new Manager { Name="Olena", Profession="Manager", Education="вища", BirthDate=new DateTime(1988,10,14), Experience=10, Salary=20000 },
            new Manager { Name="Serhii", Profession="Manager", Education="вища", BirthDate=new DateTime(1995,4,3), Experience=7, Salary=18000 },
            new Worker { Name="Volodymyr", Profession="Engineer", Education="вища", BirthDate=new DateTime(1999,2,25), Experience=4, Salary=15000 },
            new Worker { Name="Andrii", Profession="Technician", Education="середня", BirthDate=new DateTime(1985,10,9), Experience=12, Salary=12000 },
            new Worker { Name="Volodymyr", Profession="Mechanic", Education="вища", BirthDate=new DateTime(2001,8,16), Experience=3, Salary=10000 },
            new Worker { Name="Petro", Profession="Welder", Education="середня", BirthDate=new DateTime(1990,10,1), Experience=15, Salary=11000 },
            new Worker { Name="Nazar", Profession="Builder", Education="вища", BirthDate=new DateTime(1992,5,27), Experience=9, Salary=13000 },
            new Worker { Name="Oleh", Profession="Electrician", Education="вища", BirthDate=new DateTime(1980,10,3), Experience=20, Salary=14000 },
            new Worker { Name="Volodymyr", Profession="Driver", Education="середня", BirthDate=new DateTime(1997,10,21), Experience=6, Salary=9000 },
            new Worker { Name="Kateryna", Profession="Accountant", Education="вища", BirthDate=new DateTime(1996,12,11), Experience=5, Salary=16000 },
            new Worker { Name="Taras", Profession="Programmer", Education="вища", BirthDate=new DateTime(1994,3,2), Experience=8, Salary=17000 }
        };

        // 1️ Кількість робітників підприємства
        int workersCount = company.Employers.Count(e => e is Worker);
        Console.WriteLine("Кількість робітників підприємства: " + workersCount);

        // 2️ Загальний обсяг заробітної платні
        decimal totalSalary = company.Employers.Sum(e => e.Salary);
        Console.WriteLine("Загальна сума зарплат: " + totalSalary);

        // 3️ 10 робітників з найбільшим стажем, серед яких наймолодший з вищою освітою
        var topByExperience = company.Employers
            .OrderByDescending(e => e.Experience)
            .Take(10)
            .Where(e => e.Education == "вища")
            .OrderBy(e => e.BirthDate)
            .FirstOrDefault();

        Console.WriteLine("\nНаймолодший серед досвідчених (з вищою освітою): " + topByExperience?.Name);

        // 4️ Наймолодший та найстарший менеджери
        var managers = company.Employers.Where(e => e.Profession == "Manager").ToList();
        var youngestManager = managers.OrderByDescending(e => e.BirthDate).First();
        var oldestManager = managers.OrderBy(e => e.BirthDate).First();

        Console.WriteLine("\nНаймолодший менеджер: " + youngestManager.Name);
        Console.WriteLine("Найстарший менеджер: " + oldestManager.Name);

        // 5️ Працівники, народжені у жовтні
        var octoberWorkers = company.Employers
            .Where(e => e.BirthDate.Month == 10)
            .OrderBy(e => e.Profession)
            .ToList();

        Console.WriteLine("\nПрацівники, народжені у жовтні:");
        foreach (var e in octoberWorkers)
            Console.WriteLine($"{e.Name} ({e.Profession}) – {e.BirthDate.ToShortDateString()}");

        // 6️ Усі Володимири
        var volodymyrs = company.Employers
            .Where(e => e.Name == "Volodymyr")
            .ToList();

        Console.WriteLine("\nУсі Володимири:");
        foreach (var v in volodymyrs)
            Console.WriteLine($"{v.Name}, {v.Profession}, {v.BirthDate.ToShortDateString()}");

        // Наймолодший Володимир — премія 1/3 від окладу
        var youngestVolodymyr = volodymyrs.OrderByDescending(v => v.BirthDate).First();
        decimal bonus = youngestVolodymyr.Salary / 3;
        Console.WriteLine($"\n🎉 Вітаємо {youngestVolodymyr.Name} з премією {bonus} грн!");
    }
}
