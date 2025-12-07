using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LB1._44
{
    class DictionaryLang

    {
        public List<DictionaryEntry> Entries { get; set; } = new List<DictionaryEntry>();

        // Додати слово
        public void AddEntry(string english, string ukrainian)
        {
            Entries.Add(new DictionaryEntry(english, ukrainian));
        }

        // Пошук перекладу
        public string Translate(string english)
        {
            var entry = Entries.Find(e => e.English.Equals(english, StringComparison.OrdinalIgnoreCase));
            return entry != null ? entry.Ukrainian : "Слово не знайдено";
        }

        // Показати всі слова
        public void ShowAll()
        {
            if (Entries.Count == 0) Console.WriteLine("Словник порожній");
            else
                foreach (var e in Entries)
                    Console.WriteLine(e);
        }
    }
}