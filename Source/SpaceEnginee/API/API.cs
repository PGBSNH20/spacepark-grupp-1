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
        public static async Task<Character> CharacterSelection()
        {
            bool characterSelection = true;
            CharacterResponse charactersReturned = new();
            int selection = -1;

            while (characterSelection)
            {
                Console.WriteLine("Hello Traveler, Welcome to SpacePark!\n");
                Console.Write("Enter your name: "); // Ask the user for their name.
                string input = Console.ReadLine(); // Save the name to a variable.
                charactersReturned = await API.ValidateCharacter(input); // Call the ValidateCharacter method to check if the user input is a valid SW character.

                if (charactersReturned.Results.Count != 0) // As long as the list we get from the ValidateCharacter method is not empty, let the user choose who he / she is.
                {
                    string[] characters = charactersReturned.Results.Select(x => x.Name).ToArray(); // Create a stringArray to store the Characters in for the showMenu .
                    selection = Menu.ShowMenu("\nWho are you?", characters); // Let the user select who they are from the list.
                    Console.Clear();
                    Console.WriteLine($"\nWelcome {charactersReturned.Results[selection].Name}"); // Greet the Character .
                    characterSelection = false;
                }
                else // If there is no match, ask if user want to try again
                {
                    int _continue = Menu.ShowMenu("Do you wish to try again?", new[] { "Yes", "No" });
                    if (_continue == 1) // If the do not want to try again, close the application.
                    {
                        Environment.Exit(0);
                    }
                }
            }
            return charactersReturned.Results[selection]; // Return one character from the list of characters based on index from showMenu.
        }

        public static async Task<CharacterResponse> ValidateCharacter(string input)
        {
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest($"people/?search={input}", DataFormat.Json); // Use the swAPI search function with the user input string.
            var peopleResponse = await client.GetAsync<CharacterResponse>(request); // Add the results from the search to the CharachterResponse List
            return peopleResponse; // Return the List with characters to the CharacterSelection method.
        }

        public static async Task<Starship> GetStarShips(Character character) // Takes a character object as argument.
        {
            List<Starship> ships = await API.ValidateStarship(character.StarShips); // Creates a list of starships and call the ValidateStarship method, and pass the
                                                                                    // charachters starship list as argument (list of ship url's)
            int selection = -1;
            if (ships.Count > 0) // If the ships list contains at least one ship, let the user select current ship with showMenu
            {
                string[] shipOptions = ships.Select(s => s.Name).ToArray();
                selection = Menu.ShowMenu("\nChoose your ship", shipOptions);
                Console.WriteLine("\nYou selected" + " " + ships[selection].Name);
            }
            else // If the character do not own any ships, prompt and quit the application.
            {
                Console.WriteLine("\nYou have no ships");
                Environment.Exit(0);
            }
            Console.Clear();
            return ships[selection]; // Return the selected ship.
        }

        public static async Task<List<Starship>> ValidateStarship(List<string> starshipUrls)
        {
            List<Starship> ships = new(); // Create a temporary list of starships.
            foreach (var url in starshipUrls) // iterate through every url from character's shiplist.
            {
                var client = new RestClient(url); // In every iteration add the current iteration's url as base URL
                var request = new RestRequest(Method.GET);
                var response = await client.GetAsync<Starship>(request); // Call the api to get the current ship object from the shipURL.
                ships.Add(response); // add the current ship to the shipsList.
            }
            return ships; // Return the list of ship object's to the GetStarShips method. 
        }
    }
}
