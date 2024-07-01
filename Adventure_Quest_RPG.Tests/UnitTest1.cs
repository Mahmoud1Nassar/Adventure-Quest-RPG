using Xunit;
using Adventure_Quest_RPG;

namespace Adventure_Quest_RPG.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Attack_PlayerAttacksEnemy_EnemyHealthReduces()
        {
            Player player = new Player("Hero");
            Monster enemy = new Goblin("Goblin");
            BattleSystem battleSystem = new BattleSystem();

            int initialHealth = enemy.Health;
            battleSystem.Attack(player, enemy);

            Assert.True(enemy.Health < initialHealth, $"Expected {enemy.Name}'s health to be less than {initialHealth} but was {enemy.Health}");
        }

        [Fact]
        public void Attack_EnemyAttacksPlayer_PlayerHealthReduces()
        {
            Player player = new Player("Hero");
            Monster enemy = new Dragon("Dragon");
            BattleSystem battleSystem = new BattleSystem();

            int initialHealth = player.Health;
            battleSystem.Attack(enemy, player);

            Assert.True(player.Health < initialHealth, $"Expected {player.Name}'s health to be less than {initialHealth} but was {player.Health}");
        }

        [Fact]
        public void StartBattle_PlayerDefeatsEnemy_PlayerHealthGreaterThanZero()
        {
            Player player = new Player("Hero");
            Monster enemy = new Goblin("Goblin");
            BattleSystem battleSystem = new BattleSystem();

            battleSystem.StartBattle(player, enemy);

            Assert.True(player.Health > 0, $"Expected {player.Name}'s health to be greater than zero but was {player.Health}");
            Assert.True(enemy.Health == 0, $"Expected {enemy.Name}'s health to be zero but was {enemy.Health}");
        }

        [Fact]
        public void StartBattle_EnemyDefeatsPlayer_EnemyHealthGreaterThanZero()
        {
            Player player = new Player("Hero");
            Monster enemy = new Dragon("Dragon");
            BattleSystem battleSystem = new BattleSystem();

            battleSystem.StartBattle(player, enemy);

            Assert.True(player.Health == 0, $"Expected {player.Name}'s health to be zero but was {player.Health}");
            Assert.True(enemy.Health > 0, $"Expected {enemy.Name}'s health to be greater than zero but was {enemy.Health}");
        }
    }
}
