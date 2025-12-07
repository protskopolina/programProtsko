using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;


class Program
{
    static void Main()
    {
        List<MilitaryCard> cards = new List<MilitaryCard>
        {
            new MilitaryCard { FullName = "Іванов І. І.", BirthDate = new DateTime(2001,5,10), Address="Київ", FitnessLevel="Придатний", PossibleDraftDate=new DateTime(2025,4,15) },
            new MilitaryCard { FullName = "Петров П. П.", BirthDate = new DateTime(2002,11,1), Address="Львів", FitnessLevel="Обмежено придатний", PossibleDraftDate=new DateTime(2025,10,5) },
            new MilitaryCard { FullName = "Сидоров С. С.", BirthDate = new DateTime(2003,2,20), Address="Одеса", FitnessLevel="Придатний", PossibleDraftDate=new DateTime(2025,6,1) }
        };

        // Додавання, редагування, видалення
        cards.Add(new MilitaryCard { FullName = "Поліщук К. К.", BirthDate = new DateTime(2001, 8, 15), Address = "Харків", FitnessLevel = "Придатний", PossibleDraftDate = new DateTime(2025, 4, 1) });
        cards.Add(new MilitaryCard { FullName = "Коваленко К. К.", BirthDate = new DateTime(2001, 7, 15), Address = "Дніпро", FitnessLevel = "Придатний", PossibleDraftDate = new DateTime(2025, 10, 18) });
        cards[0].Address = "Київ, вул. Хрещатик, 10";
        cards.RemoveAt(1);

        // Вивід і запис
        using (StreamWriter w = new StreamWriter("result.txt"))
        {
            PrintAndWrite(w, "=== Усі записи ===", cards);
            PrintAndWrite(w, "=== Весняний призов ===", cards, 4, 6);
            PrintAndWrite(w, "=== Осінній призов ===", cards, 10, 12);
        }

        Console.WriteLine("\n Результат записано у result.txt");
    }

    // Універсальний метод: вивід у консоль і запис у файл, з опційною фільтрацією за місяцем
    static void PrintAndWrite(StreamWriter w, string header, List<MilitaryCard> list, int startMonth = 1, int endMonth = 12)
    {
        Console.WriteLine(header);
        w.WriteLine(header);

        foreach (var card in list)
        {
            int month = card.PossibleDraftDate.Month;
            if (month >= startMonth && month <= endMonth)
            {
                Console.WriteLine(card);
                w.WriteLine(card);
            }
        }
    }
}
