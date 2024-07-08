using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Quest_RPG
{
    public class Location
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Location(string name, string description) {
            Name = name;
            Description = description;
        }
        public override string ToString() { 
            return $"{Name} - {Description}";
        }
    }
}
