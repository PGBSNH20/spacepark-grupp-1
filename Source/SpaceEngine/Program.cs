using RestSharp;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SpaceEngine
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            List<string> test = new List<string>();
            test.Add("https://swapi.dev/api/starships/16/");

            var vader = SpaceOrm.ValidateStarship(test);

            foreach (var a in vader)
            {
                Console.WriteLine(a.re);
            }

            Spacepark first = new Spacepark()
            {
                Name = "First"
            };

            Parkingspot.Small hej = new Parkingspot.Small()
            {
                Arrival = DateTime.Now,
                Departure = DateTime.Now.AddHours(1),
                Starship = vader.Result[0]
            };

            Console.WriteLine(hej.Starship.Name);










            //bool menuGoing = true;
            //Character character = await SpaceOrm.CharacterSelection();
            //Starship starship = await SpaceOrm.GetStarShips(character);

            //while (menuGoing)
            //{
            //    int selectedOption = Menu.ShowMenu($"What do you want to do {character.Name}?\n", new[]
            //    {
            //        "Park Vehicle",
            //        "Unpark Vehicle",
            //        "Show parking history",
            //         "Exit"
            //    });

            //    if(selectedOption == 3)
            //    {
            //        menuGoing = false;
            //        Console.WriteLine("Have a nice day!");
            //    }
            //}


        }
    }
}
