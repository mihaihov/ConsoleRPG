using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    internal class Weapon
    {
        public Weapon(string mName, Range? mDamageRange)
        {
            this.Name = mName;
            this.DamageRange = mDamageRange;
        }

        public string Name { get; set; } = string.Empty;
        public Range? DamageRange { get; set; }
    }
}
