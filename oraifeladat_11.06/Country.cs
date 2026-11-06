using System.Collections.Generic;
using System.Windows.Media;

namespace oraifeladat_11._06
{
    public class Country
    {
        public string Name { get; set; }
        public List<string> Synonyms { get; set; }
        public Brush TopBand { get; set; }
        public Brush MiddleBand { get; set; }
        public Brush BottomBand { get; set; }

        public Country(string name, List<string> synonyms, Brush top, Brush middle, Brush bottom)
        {
            Name = name;
            Synonyms = synonyms;
            TopBand = top;
            MiddleBand = middle;
            BottomBand = bottom;
        }

        public bool Matches(string inputName, Brush top, Brush middle, Brush bottom)
        {
            return Synonyms.Contains(inputName.ToLower().Trim()) &&
                   TopBand == top &&
                   MiddleBand == middle &&
                   BottomBand == bottom;
        }
    }
}
