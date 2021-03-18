using RestSharp;
using System;
using System.Threading.Tasks;

namespace SpaceEngine
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //var client = new RestClient("https://swapi.dev/api/");
            //var request = new RestRequest("people/", DataFormat.Json);
            //var peopleResponse = await client.GetAsync<PeopleReponse>(request);

            //foreach (var p in peopleResponse.Results)
            //{
            //    Console.WriteLine(p.Name + " " + p.Gender);
            //}
            //Console.ReadKey();
            await SpaceOrm.GetStarShips();


            // Nästa steg, lägg till alla spaceships i databasen samt karaktärer.
            var context = new MyContext();
            var character = new Character()
            {
                Name = "Luke SkyWalker",
                Gender = "Male",
                Height = 177
            };
            context.Character.Add(character);
            context.SaveChanges();
            Console.WriteLine("Data Saved");
        }
    }
}
