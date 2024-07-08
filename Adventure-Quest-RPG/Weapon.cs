namespace Adventure_Quest_RPG
{
    public class Weapon : Item
    {
        public int AttackPower { get; private set; }

        public Weapon(string name, string description, int attackPower)
            : base(name, description)
        {
            AttackPower = attackPower;
        }
    }
}
