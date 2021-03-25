using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceEngine.Utils;

namespace SpaceEngine
{
    public class Menu
    {
        public static void Start(Character character, Starship starship)
        {
            bool menuGoing = true;
            while (menuGoing)
            {
                Console.Clear();
                menuGoing = ParkMenu(character, starship);
            }
        }

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
                peopleResponse = await API.ValidateCharacter(input);
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
        public static async Task<Starship> GetStarShips(Character character)
        {
            List<Starship> ships = await API.ValidateStarship(character.StarShips);
            int selection = -1;
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
        public static int ShowMenu(string prompt, string[] options)
        {
            if (options == null || options.Length == 0)
            {
                throw new ArgumentException("Cannot show a menu for an empty array of options.");
            }

            Console.WriteLine(prompt);

            int selected = 0;

            // Hide the cursor that will blink after calling ReadKey.
            Console.CursorVisible = false;

            ConsoleKey? key = null;
            while (key != ConsoleKey.Enter)
            {
                // If this is not the first iteration, move the cursor to the first line of the menu.
                if (key != null)
                {
                    Console.CursorLeft = 0;
                    Console.CursorTop = Console.CursorTop - options.Length;
                }

                // Print all the options, highlighting the selected one.
                for (int i = 0; i < options.Length; i++)
                {
                    var option = options[i];
                    if (i == selected)
                    {
                        //Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.WriteLine("- " + option);
                    Console.ResetColor();
                }

                // Read another key and adjust the selected value before looping to repeat all of this.
                key = Console.ReadKey().Key;
                if (key == ConsoleKey.DownArrow)
                {
                    selected++;
                    if (selected > options.Length - 1)
                    {
                        selected = 0;
                    }
                }
                else if (key == ConsoleKey.UpArrow)
                {
                    selected--;
                    if (selected < 0)
                    {
                        selected = options.Length - 1;
                    }
                }
            }

            // Reset the cursor and return the selected option.
            Console.CursorVisible = true;
            return selected;
        }
        public static bool ParkMenu(Character character, Starship starship)
        {
            {
                bool menuGoing = true;
                using var context = new MyContext();
                var shipFound = context.Parkingspots.Where(p => p.SpaceshipName == starship.Name && p.CharacterName == character.Name);
                int selectedOption;
                string[] options = new[]
                {
                "Park Vehicle",
                "Unpark Vehicle",
                "Show parking history",
                "Choose Another character",
                "Exit"
            };
                if (shipFound.Any())
                {
                    selectedOption = 1 + Menu.ShowMenu($"What do you want to do with your {starship.Name}, {character.Name}?\n", options.Skip(1).ToArray());
                }
                else
                {
                    selectedOption = Menu.ShowMenu($"What do you want to do with your {starship.Name}, {character.Name}?\n", options);
                }
                switch (selectedOption)
                {
                    case 0:
                        Parkingspot.Park(starship, character);
                        break;
                    case 1:
                        Parkingspot.Unpark(starship, character);
                        break;
                    case 2:
                        Parkingspot.ShowHistory(starship, character);
                        break;
                    case 3:
                        Console.Clear();
                        Character newCharacter = Menu.CharacterSelection().Result;
                        Starship newShip = Menu.GetStarShips(newCharacter).Result;
                        menuGoing = false;
                        Menu.Start(newCharacter, newShip);
                        break;
                    default:
                        Console.WriteLine("\nHave a nice day!");
                        Environment.Exit(0);
                        break;
                }
                menuGoing = Menu.Continue(character);
                return menuGoing;
            }
        }

        public static bool Continue(Character character)
        {
            bool menuGoing = true;
            int selectedOption = Menu.ShowMenu($"\nWould you like to continue {character.Name}?\n", new[]
            {
                "Yes",
                "Exit"
            });
            if (selectedOption == 1)
            {
                Console.WriteLine("\nHave a nice day!");
                menuGoing = false;
            }
            return menuGoing;
        }

    }
}
