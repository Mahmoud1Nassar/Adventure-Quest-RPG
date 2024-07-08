namespace Adventure_Quest_RPG
{
    public class Armor : Item
    {
        public int Defense { get; private set; }

        public Armor(string name, string description, int defense)
            : base(name, description)
        {
            Defense = defense;
        }
    }
}
