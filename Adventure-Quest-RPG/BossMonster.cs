using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Quest_RPG
{
    public class BossMonster : Monster
    {
        public BossMonster(string name) : base(name, 1000,300 )
        {
            RandomizeDefense();
        }
    }
}
