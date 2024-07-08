using System;

namespace Adventure_Quest_RPG
{
    public class Player : IBattleStates
    {
        private static Random random = new Random();

        public string Name { get; private set; }
        public int Health { get; set; } // Setter is now public
        public int AttackPower { get; private set; }
        public int Defense { get; private set; }
        public Inventory Inventory { get; private set; }

        public Player(string name)
        {
            Name = name;
            Health = 100;
            AttackPower = 10;
            RandomizeDefense();
            Inventory = new Inventory();
        }

        public void RandomizeDefense()
        {
            Defense = random.Next(5, 16);
        }

        public void ReduceHealth(int amount)
        {
            Health = Math.Max(0, Health - amount);
        }

        public void UseItem(string itemName)
        {
            Item item = Inventory.GetItem(itemName);
            if (item != null)
            {
                if (item is Potion potion)
                {
                    Health = Math.Min(100, Health + potion.HealthRestore);
                    Console.WriteLine($"Used {potion.Name}. Restored {potion.HealthRestore} health.");
                    Inventory.RemoveItem(potion);
                }
                else if (item is Weapon weapon)
                {
                    AttackPower += weapon.AttackPower;
                    Console.WriteLine($"Equipped {weapon.Name}. Attack power increased by {weapon.AttackPower}.");
                    Inventory.RemoveItem(weapon);
                }
                else if (item is Armor armor)
                {
                    Defense += armor.Defense;
                    Console.WriteLine($"Equipped {armor.Name}. Defense increased by {armor.Defense}.");
                    Inventory.RemoveItem(armor);
                }
            }
        }
    }
}
