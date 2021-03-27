using System;
using Xunit;
using SpaceEngine;
using System.Collections.Generic;

namespace SpaceParkTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("Luke Skywalker")]
        [InlineData("Leia Organa")]
        [InlineData("Darth Vader")]
        public void ValidateCharacter_CorrectInput_ExpectTrue(string input)
        {
            var character = API.ValidateCharacter(input);
            bool isTraveler = character.Result.Results[0].Name == input;
            Assert.True(isTraveler);
        }

        [Theory]
        [InlineData("Jonas Schmedtmann")]
        [InlineData("Spacejam george")]
        [InlineData("Darth Peter")]
        public void ValidateCharacter_IncorrectInput_ExpectFalse(string input)
        {
            var character = API.ValidateCharacter(input);
            bool isTraveler = character.Result.Results.Count == 1;
            Assert.False(isTraveler);
        }

        [Theory]
        [InlineData("https://swapi.dev/api/starships/12/", "https://swapi.dev/api/starships/16/")]
        public void ValidateStarship_CorrectInpute_ExpectTrue(string input, string input2)
        {
            List<string> ships = new();
            ships.Add(input);
            ships.Add(input2);

            var ship = API.ValidateStarship(ships);
            bool isShip = ship.Result.Count == 2;
            Assert.True(isShip);
        }
    }
}
