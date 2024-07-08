namespace Adventure_Quest_RPG
{
    public abstract class Item
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }

        protected Item(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
