using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceEngine
{
    public class API
    {
        // Using the API search function to get the Character       
        public static async Task<CharacterResponse> ValidateCharacter(string input)
        {
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest($"people/?search={input}", DataFormat.Json);
            var peopleResponse = await client.GetAsync<CharacterResponse>(request);
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

        public static async Task<Character> CharacterSelection()
        {
            bool characterSelection = true;
            CharacterResponse charactersReturned = new();
            int selection = -1;
            while (characterSelection)
            {
                Console.WriteLine("Hello Traveler, Welcome to SpacePark!\n");
                Console.Write("Enter your name: ");
                string input = Console.ReadLine();
                charactersReturned = await API.ValidateCharacter(input);
                if (charactersReturned.Results.Count != 0)
                {
                    string[] characters = charactersReturned.Results.Select(x => x.Name).ToArray();
                    selection = Menu.ShowMenu("\nWho are you?", characters);
                    Console.Clear();
                    Console.WriteLine($"\nWelcome {charactersReturned.Results[selection].Name}");
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
            return charactersReturned.Results[selection];
        }

        public static async Task<Starship> GetStarShips(Character character)
        {
            List<Starship> ships = await API.ValidateStarship(character.StarShips);
            int selection = -1;
            if (ships.Count > 0)
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
    }
}
