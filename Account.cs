using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIProjekat1
{
    class Account
    {
        public int AccountId { get; set; }
        public string Type { get; set; }
        public string Username {  get; set; }
        public string Password { get; set; }
        public DateTime? DateOfCreation { get; set; }
        public DateTime? DateOfRequest { get; set; }
        public string Info { get; set; }   
        public string Theme { get; set; }

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
