using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIProjekat1
{
    public class Team
    {
        public string Name { get; set; }
        public int YearOfEstablishment { get; set; }
        public string Country { get; set; }
        public byte[] Picture { get; set; }

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
            return Name;
        }
    }
}
