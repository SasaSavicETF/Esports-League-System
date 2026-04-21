using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIProjekat1
{
    class Match
    {
        public int MatchId { get; set; }
        public string Format { get; set; }
        public string Team1 { get; set; }
        public string Result { get; set; }
        public string Team2 { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public Phase Phase { get; set; }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
