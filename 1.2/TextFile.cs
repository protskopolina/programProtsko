using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb1._2
{

    class FileList
    {
        private string path;

        public FileList(string path)
        {
            this.path = path;
        }

        public string[] GetFiles()
        {
            if (!File.Exists(path))
            {
                Console.WriteLine($"Файл {path} не знайдено!");
                return new string[0];
            }

            return File.ReadAllLines(path);
        }
    }
}
                       