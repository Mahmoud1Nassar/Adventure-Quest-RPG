using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Quest_RPG
{
    public interface IBattleStates
    {
        string Name { get; }
        int Health { get; }
        int AttackPower { get; }
        int Defense { get; }
    }
}
