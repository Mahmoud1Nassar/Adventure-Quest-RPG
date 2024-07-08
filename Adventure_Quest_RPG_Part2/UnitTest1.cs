using System;
using System.Collections.Generic;
using Xunit;
using Adventure_Quest_RPG;

namespace Adventure_Quest_RPG_Part2
{
    public class UnitTest1
    {
        [Fact]
        public void Test_Encountering_Boss_Monster()
        {
            // Arrange
            var player = new Player("TestPlayer");
            var adventure = new Adventure(player);

            // Force encounter with BossMonster
            var bossMonster = new BossMonster("Dragon Boss");

            // Act
            adventure.TestEncounterMonster(bossMonster);

            // Assert
            Assert.Equal("Dragon Boss", bossMonster.Name);
        }

        [Fact]
        public void Test_Moving_To_New_Location()
        {
            // Arrange
            var player = new Player("TestPlayer");
            var adventure = new Adventure(player);
            adventure.InitializeLocations();

            // Simulate player moving to a new location
            int newLocationIndex = 2; // Example: Dark Cave
            adventure.TestMoveToLocation(newLocationIndex);

            // Assert
            Assert.Equal("Dark Cave", adventure.CurrentLocation.Name);
        }
    }
}