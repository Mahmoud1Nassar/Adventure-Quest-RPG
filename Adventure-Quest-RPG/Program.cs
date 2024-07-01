using static Adventure_Quest_RPG.Monster;

namespace Adventure_Quest_RPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Player player = new Player("Hero");
                Monster enemy = new Dragon("Dragon");

                BattleSystem battleSystem = new BattleSystem();
                battleSystem.StartBattle(player, enemy);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
