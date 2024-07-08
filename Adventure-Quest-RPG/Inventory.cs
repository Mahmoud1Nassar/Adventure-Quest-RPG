using System;
using System.Collections.Generic;

namespace Adventure_Quest_RPG
{
    public class Inventory
    {
        private List<Item> items;

        public Inventory()
        {
            items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            items.Add(item);
            Console.WriteLine($"{item.Name} has been added to your inventory.");
        }

        public void DisplayInventory()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Your inventory is empty.");
                return;
            }

            Console.WriteLine("Inventory:");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Name} - {item.Description}");
            }
        }

        public Item GetItem(string itemName)
        {
            foreach (var item in items)
            {
                if (item.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase))
                {
                    return item;
                }
            }
            Console.WriteLine($"Item {itemName} not found in inventory.");
            return null;
        }

        public void RemoveItem(Item item)
        {
            if (items.Remove(item))
            {
                Console.WriteLine($"{item.Name} has been removed from your inventory.");
            }
        }
    }
}
