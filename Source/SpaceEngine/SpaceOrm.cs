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
        // Using the API search function to get the Character
        public static async Task<Character> CharacterSelection()
        {
            bool characterSelection = true;
            PeopleReponse peopleResponse = new();
            int selection = -1;
            while (characterSelection)
            {
                Console.WriteLine("Hello Traveler, Welcome to SpacePark!\n");
                Console.Write("Enter your name: ");
                string input = Console.ReadLine();
                peopleResponse = await ValidateCharacter(input);
                if (peopleResponse.Results.Count != 0)
                {
                    string[] characters = peopleResponse.Results.Select(x => x.Name).ToArray();
                    selection = Menu.ShowMenu("\nWho are you?", characters);
                    Console.Clear();
                    Console.WriteLine($"\nWelcome {peopleResponse.Results[selection].Name}");
                    characterSelection = false;
                }
                else
                {
                    int _continue = Menu.ShowMenu("Do you wish to try again?", new[] { "Yes", "No" });
                    if (_continue == 1)
                    {
                        Environment.Exit(0);
                    }
                }
            }
            return peopleResponse.Results[selection];
        }

        public static async Task<Starship> GetStarShips(List<string> starshipUrls)
        {
            List<Starship> ships = new();
            int selection = -1;

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
                selection = Menu.ShowMenu("\nChoose your ship", shipOptions);
                Console.WriteLine("\nYou selected" + " " + ships[selection].Name);
            }
            else
            {
                Console.WriteLine("\nYou have no ships");
                Environment.Exit(0);
            }
            Console.Clear();
            return ships[selection];
        }

        public static async Task<PeopleReponse> ValidateCharacter(string input)
        {
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest($"people/?search={input}", DataFormat.Json);
            var peopleResponse = await client.GetAsync<PeopleReponse>(request);
            return peopleResponse;
        }
    }
}
