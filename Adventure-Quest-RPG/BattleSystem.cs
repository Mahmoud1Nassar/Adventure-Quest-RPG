using System;

namespace Adventure_Quest_RPG
{
    public class BattleSystem
    {
        private static Random random = new Random();

        public void Attack(IBattleStates attacker, IBattleStates target)
        {
            if (target is Player playerTarget)
            {
                playerTarget.RandomizeDefense();
            }
            else if (target is Monster monsterTarget)
            {
                monsterTarget.RandomizeDefense();
            }

            int damage = Math.Max(attacker.AttackPower - target.Defense, 0);

            Console.WriteLine($"[{attacker.Name} attacks {target.Name}]");
            Console.WriteLine($"  - {target.Name}'s defense: {target.Defense}");
            Console.WriteLine($"  - Calculated damage: {damage}");

            if (target is Player)
            {
                (target as Player).ReduceHealth(damage);
            }
            else if (target is Monster)
            {
                (target as Monster).ReduceHealth(damage);
            }

            Console.WriteLine($"  - {target.Name}'s updated health: {target.Health}");
            Console.WriteLine(new string('-', 30)); // Separator for readability

            if (target.Health <= 0 && target is Monster)
            {
                HandleItemDrop(attacker as Player);
            }
        }

        private void HandleItemDrop(Player player)
        {
            int dropChance = random.Next(1, 101); // 1 to 100 percent chance

            if (dropChance <= 20) // 20% chance to drop an item
            {
                Item droppedItem = GenerateRandomItem();
                player.Inventory.AddItem(droppedItem);
            }
        }

        private Item GenerateRandomItem()
        {
            int itemType = random.Next(1, 4); // 1 to 3

            switch (itemType)
            {
                case 1:
                    return new Weapon("Sword", "A sharp blade.", random.Next(5, 16));
                case 2:
                    return new Armor("Shield", "Provides protection.", random.Next(3, 10));
                case 3:
                    return new Potion("Health Potion", "Restores health.", random.Next(10, 31));
                default:
                    return null;
            }
        }

        public void StartBattle(Player player, Monster enemy)
        {
            Console.WriteLine("Battle Start!");
            Console.WriteLine(new string('=', 30)); // Separator for the start of the battle

            // Reset player health for each battle
            player.Health = 100;

            while (player.Health > 0 && enemy.Health > 0)
            {
                Console.WriteLine("Player's turn:");
                Attack(player, enemy);

                if (enemy.Health <= 0)
                {
                    Console.WriteLine($"{enemy.Name} is defeated! You win!");
                    Console.WriteLine("Adventure complete!");
                    return;
                }

                Console.WriteLine("Enemy's turn:");
                Attack(enemy, player);

                if (player.Health <= 0)
                {
                    Console.WriteLine($"{player.Name} is defeated! You lose!");
                    return;
                }
            }
        }
    }
}
