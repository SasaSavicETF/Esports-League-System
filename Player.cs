using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIProjekat1
{
    class Player
    {
        public string InGameId { get; set; }
        public string FirstName { get; set; }   
        public string LastName { get; set; }
        public string Position { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }

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
