using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb1._3
{
    public class PrintJob
    {
        public string User { get; set; }       // ім’я користувача
        public string Document { get; set; }   // назва документу
        public int Priority { get; set; }      // пріоритет: 1 – високий, 2 – середній, 3 – низький
        public DateTime TimeAdded { get; set; }

        public PrintJob(string user, string document, int priority)
        {
            User = user;
            Document = document;
            Priority = priority;
            TimeAdded = DateTime.Now;
        }

        public override string ToString()
        {
            return $"[{TimeAdded:HH:mm:ss}] {User} - {Document} (Priority: {Priority})";
        }
    }
}
