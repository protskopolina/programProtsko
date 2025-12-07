using System;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleApp1;

class Program
{
    static void Main()
    {
        var firms = new List<Firma>
        {
            new Firma{ Nazva="FoodMarket", Data=new DateTime(2020,5,10), Profil="Маркетинг", Dyrektor="John White", Spivrob=120, Misto="Лондон" },
            new Firma{ Nazva="TechIT", Data=new DateTime(2023,2,5), Profil="IT", Dyrektor="Anna Black", Spivrob=250, Misto="Манчестер" },
            new Firma{ Nazva="FoodExpress", Data=new DateTime(2021,8,15), Profil="Логістика", Dyrektor="Michael White", Spivrob=90, Misto="Лондон" },
            new Firma{ Nazva="MarketPro", Data=new DateTime(2019,3,1), Profil="Маркетинг", Dyrektor="Sarah Green", Spivrob=310, Misto="Бірмінгем" },
            new Firma{ Nazva="WhiteTech", Data=new DateTime(2022,6,20), Profil="IT", Dyrektor="Tom Black", Spivrob=150, Misto="Лондон" }
        };

        var res = from f in firms
                  where f.Spivrob > 100
                  select f.Nazva;

        foreach (var n in res)
            Console.WriteLine(n);
    }
}


