using System.Numerics;
using System;
using Adventure_Quest_RPG;
namespace Adventure_Quest_Part3
{
    public class UnitTest1
    {
        [Fact]
        public void Test_Item_Drop_After_Battle()
        {
            // Arrange
            var player = new Player("TestPlayer");
            var adventure = new Adventure(player);
            var battleSystem = new BattleSystem();
            var monster = new Goblin("Goblin");

            // Act
            battleSystem.StartBattle(player, monster);

            // Assert
            Assert.True(player.Inventory != null);
        }

        [Fact]
        public void Test_Use_Potion()
        {
            // Arrange
            var player = new Player("TestPlayer");
            player.Inventory.AddItem(new Potion("Health Potion", "Restores health", 20));

            // Act
            player.UseItem("Health Potion");

            // Assert
            Assert.True(player.Health > 50); // Health should be increased
        }

        [Fact]
        public void Test_Use_Weapon()
        {
            // Arrange
            var player = new Player("TestPlayer");
            player.Inventory.AddItem(new Weapon("Sword", "A sharp blade", 10));

            // Act
            player.UseItem("Sword");

            // Assert
            Assert.True(player.AttackPower > 10); // Attack power should be increased
        }

        [Fact]
        public void Test_Use_Armor()
        {
            // Arrange
            var player = new Player("TestPlayer");
            player.Inventory.AddItem(new Armor("Shield", "Provides protection", 5));

            // Act
            player.UseItem("Shield");

            // Assert
            Assert.True(player.Defense > 5); // Defense should be increased
        }
    }
}