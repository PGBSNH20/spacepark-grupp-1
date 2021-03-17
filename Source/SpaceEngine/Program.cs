using RestSharp;
using System;
using System.Threading.Tasks;

namespace SpaceEngine
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest("people/", DataFormat.Json);
            var peopleResponse = await client.GetAsync<PeopleReponse>(request);

            foreach (var p in peopleResponse.Results)
            {
                Console.WriteLine(p.Name + " " + p.Gender);
            }
            Console.ReadKey();
        }
    }
}
