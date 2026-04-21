using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIProjekat1
{
    class Season
    {
        public int SeasonId { get; set; }
        public string Split { get; set; }
        public int Year { get; set; }
        public string Display
        {
            get { return $"{Year} {Split}"; }
        }

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
