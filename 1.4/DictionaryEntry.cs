using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB1._44
{

    public class DictionaryEntry
    {
        public string English { get; set; }          // слово англійською
        public string Ukrainian { get; set; }        // переклад українською

        public DictionaryEntry(string english, string ukrainian)
        {
            English = english;
            Ukrainian = ukrainian;
        }

        public override string ToString()
        {
            return $"{English} -> {Ukrainian}";
        }