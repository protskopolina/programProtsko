using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb1._3
{
    public class PrinterQueue
    {
        private List<PrintJob> queue = new List<PrintJob>();
        public List<string> PrintHistory { get; private set; } = new List<string>();

        // Додати завдання до черги
        public void AddJob(PrintJob job)
        {
            queue.Add(job);
            // Сортуємо за пріоритетом (1 високий, 3 низький)
            queue = queue.OrderBy(j => j.Priority).ThenBy(j => j.TimeAdded).ToList();
            Console.WriteLine("Завдання додано до черги.");
        }

        // Друк наступного завдання
        public void PrintNext()
        {
            if (queue.Count == 0)
            {
                Console.WriteLine("Черга порожня.");
                return;
            }

            var job = queue[0];
            queue.RemoveAt(0);

            string record = $"[{DateTime.Now:HH:mm:ss}] Друк: {job.User} - {job.Document}";
            PrintHistory.Add(record);

            Console.WriteLine(record);
        }

        // Показати чергу
        public void ShowQueue()
        {
            if (queue.Count == 0)
            {
                Console.WriteLine("Черга порожня.");
                return;
            }

            Console.WriteLine("Черга друку:");
            foreach (var job in queue)
                Console.WriteLine(job);
        }

        // Вивести статистику
        public void ShowHistory()
        {
            if (PrintHistory.Count == 0)
            {
                Console.WriteLine("Історія друку порожня.");
                return;
            }

            Console.WriteLine("Статистика друку:");
            foreach (var record in PrintHistory)
                Console.WriteLine(record);
        }

        // Зберегти історію у файл
        public void SaveHistoryToFile(string filePath)
        {
            System.IO.File.WriteAllLines(filePath, PrintHistory);
            Console.WriteLine("Статистика збережена у файл.");
        }
    }
}