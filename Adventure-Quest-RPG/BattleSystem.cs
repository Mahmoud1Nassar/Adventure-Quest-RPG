using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Quest_RPG
{
    public class BattleSystem
    {
        public void Attack(dynamic attacker, dynamic target)
        {
            // Randomize the defense value before each attack
            target.RandomizeDefense();

            // Calculate the damage inflicted, considering the random nature of defense
            int damage = Math.Max(attacker.AttackPower - target.Defense, 0);

            // Debugging: Print defense and damage values
            Console.WriteLine($"[{attacker.Name} attacks {target.Name}]");
            Console.WriteLine($"  - {target.Name}'s defense: {target.Defense}");
            Console.WriteLine($"  - Calculated damage: {damage}");

            // Reduce the target's health by the calculated damage amount
            target.ReduceHealth(damage);

            // Display information about the attack
            Console.WriteLine($"  - {target.Name}'s updated health: {target.Health}");
            Console.WriteLine(new string('-', 30)); // Separator for readability
        }

        public void StartBattle(Player player, Monster enemy)
        {
            Console.WriteLine("Battle Start!");
            Console.WriteLine(new string('=', 30)); // Separator for the start of the battle

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
