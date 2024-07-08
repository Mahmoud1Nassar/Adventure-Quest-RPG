using static Adventure_Quest_RPG.Monster;

namespace Adventure_Quest_RPG
{
    public class Program
    {
        static void Main(string[] args)
        {
            {
                Player player = new Player("Hero");
                Adventure adventure = new Adventure(player);
                adventure.Start();
            }
        }
    }
}
