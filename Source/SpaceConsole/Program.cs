using System;
using System.Globalization;
using System.Threading.Tasks;
using SpaceEngine;
using SpaceEngine.Utils;

namespace SpaceConsole
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            Print.TakenSpots();
            Character character = await API.CharacterSelection();
            Starship starship = await API.GetStarShips(character);
            Menu.Start(character, starship);
        }
        //TODO: More Parkings
        //TODO: More Unit tests
    }
}
