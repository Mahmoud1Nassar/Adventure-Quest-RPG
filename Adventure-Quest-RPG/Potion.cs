namespace Adventure_Quest_RPG
{
    public class Potion : Item
    {
        public int HealthRestore { get; private set; }

        public Potion(string name, string description, int healthRestore)
            : base(name, description)
        {
            HealthRestore = healthRestore;
        }
    }
}
