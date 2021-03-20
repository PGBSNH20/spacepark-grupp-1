using System;
using Xunit;
using SpaceEngine;

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
            var character = SpaceOrm.ValidateCharacter(input);
            bool isTraveler = character.Result.Results[0].Name == input;
            Assert.True(isTraveler);
        }

        [Theory]
        [InlineData("Jonas Schmedtmann")]
        [InlineData("Spacejam george")]
        [InlineData("Darth Peter")]
        public void ValidateCharacter_IncorrectInput_ExpectFalse(string input)
        {
            var character = SpaceOrm.ValidateCharacter(input);
            bool isTraveler = character.Result.Results.Count == 1;
            Assert.False(isTraveler);
        }
    }
}
