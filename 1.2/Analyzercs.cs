using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb1._2
{
     class Analyzer
    {
       
            public string FileName { get; private set; }
            public Dictionary<string, int> WordCount { get; private set; }

            public Analyzer(string fileName)
            {
                FileName = fileName;
                WordCount = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            }

            public void Analyze()
            {
                if (!File.Exists(FileName))
                {
                    Console.WriteLine($"Файл {FileName} не знайдено!");
                    return;
                }

                string text = File.ReadAllText(FileName);
                string[] words = text.Split(new char[] { ' ', '\t', '\n', '\r', ',', '.', ';', ':', '!', '?', '-', '(', ')', '\"' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                {
                    string cleanWord = word.Trim();
                    if (WordCount.ContainsKey(cleanWord))
                        WordCount[cleanWord]++;
                    else
                        WordCount[cleanWord] = 1;
                }
            }

            public void Show()
            {
                Console.WriteLine($"\nСтатистика для файлу {FileName}:");
                foreach (var kvp in WordCount)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                }
            }

            public void Save()
            {
                string outputFile = FileName + "_stats.txt";
                using (StreamWriter writer = new StreamWriter(outputFile))
                {
                    foreach (var kvp in WordCount)
                    {
                        writer.WriteLine($"{kvp.Key}: {kvp.Value}");
                    }
                }
                Console.WriteLine($"Статистика збережена у файл {outputFile}");
            }
        }

    }
