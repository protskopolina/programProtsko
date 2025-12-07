using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Employer
    {
    public string Name { get; set; }              // Ім’я
        public string Profession { get; set; }        // Професія
        public string Education { get; set; }         // Освіта (вища / середня)
        public DateTime BirthDate { get; set; }       // Дата народження
        public int Experience { get; set; }           // Стаж роботи (в роках)
        public decimal Salary { get; set; }           // Зарплата
    }
}

