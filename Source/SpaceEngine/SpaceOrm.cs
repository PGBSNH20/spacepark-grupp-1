using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceEngine
{
    public class SpaceOrm
    {
        public static async Task ValidateCharacter(string input)
        {
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest($"people/?search={input}", DataFormat.Json);
            var peopleResponse = await client.GetAsync<PeopleReponse>(request);

            if (peopleResponse.Results.Count != 1)
            {
                Console.WriteLine("Invalid character");
            }
            else
            {
                Console.WriteLine($"Welcome {peopleResponse.Results[0].Name}");
                //Console.WriteLine(peopleResponse.Results[0].ShipUrls);
                await GetStarShips(peopleResponse.Results[0].StarShips);
            }
        }

        public static async Task GetStarShips(List<string> starshipUrls)
        {
            List<Starship> ships = new();
            foreach (var url in starshipUrls)
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                var response = await client.GetAsync<Starship>(request);
                ships.Add(response);
            }
            if (ships.Count != 0)
            {
                string[] shipOptions = ships.Select(s => s.Name).ToArray();
                int selection = Menu.ShowMenu("\nChoose your ship", shipOptions);

                Console.WriteLine("You selected" + " " + ships[selection].Name);
            }
            else
            {
                Console.WriteLine("You have no ships");
            }
        }
    }
}
