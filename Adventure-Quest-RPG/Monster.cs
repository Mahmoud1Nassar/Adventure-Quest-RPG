using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Adventure_Quest_RPG
{
    public abstract class Monster
    {
        private static Random random = new Random();

        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int AttackPower { get; protected set; }
        public int Defense { get; protected set; }

        protected Monster(string name, int health, int attackPower)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
            RandomizeDefense();
        }

        public void RandomizeDefense()
        {
            Defense = random.Next(3, 10);
        }

        public void ReduceHealth(int amount)
        {
            Health = Math.Max(0, Health - amount);
        }
    }

    public class Goblin : Monster
    {
        public Goblin(string name) : base(name, 30, 5) { }
    }

    public class Dragon : Monster
    {
        public Dragon(string name) : base(name, 100, 20) { }
    }
}
