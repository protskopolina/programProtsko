using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3;

        class Company
        {
            public string Name { get; set; }
            public President President { get; set; }
            public List<Employer> Employers { get; set; }

            public Company()
            {
                Employers = new List<Employer>();
            }
        }
    }

