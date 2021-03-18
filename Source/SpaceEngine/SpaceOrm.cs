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
            var starShipList = new List<Starship>();

            // Gets all the starships
            for (int i = 1; i <= 4; i++)
            {
                var client = new RestClient("https://swapi.dev/api/");
                var request = new RestRequest($"starships/?page={i}", DataFormat.Json);
                var shipResponse = await client.GetAsync<StarShipResponse>(request);
                foreach (var s in shipResponse.Results)
                {
                    starShipList.Add(s);
                }
            }
            foreach (var ship in starShipList)
            {
                Console.WriteLine($"Name:{ship.Name} Length:{ship.Length}");
            }
        }
    }
}
