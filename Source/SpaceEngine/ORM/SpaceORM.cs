using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceEngine
{
    public class SpaceORM
    {
        // Using the API search function to get the Character       
        public static async Task<PeopleReponse> ValidateCharacter(string input)
        {
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest($"people/?search={input}", DataFormat.Json);
            var peopleResponse = await client.GetAsync<PeopleReponse>(request);
            return peopleResponse;
        }
        public static async Task<List<Starship>> ValidateStarship(List<string> starshipUrls)
        {
            List<Starship> ships = new();
            foreach (var url in starshipUrls)
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                var response = await client.GetAsync<Starship>(request);
                ships.Add(response);
            }
            return ships;
        }
    }
}
