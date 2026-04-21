using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIProjekat1
{
    class Phase
    {
        public int PhaseId { get; set; }
        public string PhaseName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }   
        public Season Season { get; set; }

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
