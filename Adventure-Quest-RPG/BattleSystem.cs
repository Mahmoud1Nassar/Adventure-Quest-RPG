using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Quest_RPG
{
    public class BattleSystem
    {
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