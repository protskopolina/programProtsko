using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

public class MilitaryCard
{
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Address { get; set; }
    public string FitnessLevel { get; set; }
    public DateTime PossibleDraftDate { get; set; }

    public override string ToString()
    {
        return $"ПІБ: {FullName}, Дата народження: {BirthDate.ToShortDateString()}, Адреса: {Address}, " +
               $"Придатність: {FitnessLevel}, Можлива дата призову: {PossibleDraftDate.ToShortDateString()}";
    }
}
