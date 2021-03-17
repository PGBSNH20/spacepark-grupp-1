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
        public static async Task GetPeople()
        {
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest("people/", DataFormat.Json);
            var peopleResponse = await client.GetAsync<PeopleReponse>(request);

            foreach (var p in peopleResponse.Results)
            {
                Console.WriteLine(p.Name);
            }
            Console.ReadKey();
        }

        public static async Task GetStarShips()
        {
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest("starships/", DataFormat.Json);
            var shipResponse = await client.GetAsync<StarShipResponse>(request);

            foreach (var s in shipResponse.Results)
            {
                Console.WriteLine($"{s.Name} {s.Length}");
            }
        }
    }
}
