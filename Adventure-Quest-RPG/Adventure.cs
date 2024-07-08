using System;
using System.Collections.Generic;

namespace Adventure_Quest_RPG
{
    public class Adventure
    {
        private Player player;
        private List<Monster> monsters;
        private BattleSystem battleSystem;
        private Location currentLocation;
        private List<Location> locations;

        public Location CurrentLocation => currentLocation;

        public Adventure(Player player)
        {
            this.player = player;
            battleSystem = new BattleSystem();
            InitializeMonsters();
            InitializeLocations();
            currentLocation = locations[0]; // Start at the first location
        }

        public void InitializeMonsters()
        {
            monsters = new List<Monster>
            {
                new Goblin("Goblin"),
                new Dragon("Dragon"),
                new BossMonster("Dragon Boss")
            };
        }

        public void InitializeLocations()
        {
            locations = new List<Location>
            {
                new Location("Starting Point", "The place where your journey begins."),
                new Location("Enchanted Forest", "A forest filled with magical creatures."),
                new Location("Dark Cave", "A mysterious cave with hidden dangers."),
                new Location("Abandoned Town", "A town that has been deserted for years.")
            };
        }

        public void Start()
        {
            Console.WriteLine("Welcome to Adventure Quest!");
            bool playing = true;
            while (playing)
            {
                Console.WriteLine($"Current Location: {currentLocation.Name}");
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1. Discover a new location");
                Console.WriteLine("2. Attack a monster");
                Console.WriteLine("3. End game");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DiscoverLocation();
                        break;
                    case "2":
                        AttackMonster();
                        break;
                    case "3":
                        playing = false;
                        Console.WriteLine("Thanks for playing!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please choose again.");
                        break;
                }
            }
        }

        private void DiscoverLocation()
        {
            Console.WriteLine("Available Locations:");
            for (int i = 0; i < locations.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {locations[i].Name} - {locations[i].Description}");
            }

            Console.WriteLine("Choose a location to discover:");
            int locationChoice;
            if (int.TryParse(Console.ReadLine(), out locationChoice) && locationChoice > 0 && locationChoice <= locations.Count)
            {
                currentLocation = locations[locationChoice - 1];
                Console.WriteLine($"You have moved to: {currentLocation.Name}");
                Console.WriteLine(currentLocation.Description);
            }
            else
            {
                Console.WriteLine("Invalid choice. Please choose a valid location.");
            }
        }

        private void AttackMonster()
        {
            Random random = new Random();
            Monster monster = monsters[random.Next(monsters.Count)];
            Console.WriteLine($"You encountered a {monster.Name}!");

            battleSystem.StartBattle(player, monster);
        }

        // Helper method for testing encountering a specific monster
        public void TestEncounterMonster(Monster monster)
        {
            Console.WriteLine($"You encountered a {monster.Name}!");
            battleSystem.StartBattle(player, monster);
        }

        // Helper method for testing moving to a specific location
        public void TestMoveToLocation(int locationIndex)
        {
            if (locationIndex >= 0 && locationIndex < locations.Count)
            {
                currentLocation = locations[locationIndex];
                Console.WriteLine($"Moved to: {currentLocation.Name}");
            }
        }
    }
}
