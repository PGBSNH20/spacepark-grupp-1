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
            foreach (var line in starshipUrls)
            {
                string substringUrl = line.Substring(21);

                var client = new RestClient("https://swapi.dev/api/");
                var request = new RestRequest(substringUrl, DataFormat.Json);
                var shipResponse = await client.GetAsync<StarShipResponse>(request);

                foreach (var b in shipResponse.Results)
                {
                    Console.WriteLine($"{b.Model} - Name: {b.Name} ");
                }
            }
        }
    }
}
