using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Quest_RPG
{
    public class Player : IBattleStates
    {
        private static Random random = new Random();

        public string Name { get; private set; }
        public int Health { get; private set; }
        public int AttackPower { get; private set; }
        public int Defense { get; private set; }

        public Player(string name)
        {
            Name = name;
            Health = 100;
            AttackPower = 10;
            RandomizeDefense();
        }

        public void RandomizeDefense()
        {
            Defense = random.Next(5, 16);
        }

        public void ReduceHealth(int amount)
        {
            Health = Math.Max(0, Health - amount);
        }
    }
}
