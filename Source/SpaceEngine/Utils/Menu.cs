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
            var context = new MyContext();
            var parkingsAvailable = context.Parkingspots.Where(p => p.SpaceshipName == starship.Name);
            if (parkingsAvailable.Any())
            {
                while (menuGoing)
                {
                    int selectedOption = Menu.ShowMenu($"What do you want to do {character.Name}?\n", new[]
                    {
                       
                        "Unpark Vehicle",
                        "Show parking history",
                         "Exit"
                    });
                    
                     if (selectedOption == 0)
                     {
                        Parkingspot.Unpark(starship, character);
                     }
                    else if (selectedOption == 1)
                    {

                    }
                    else
                    {
                        menuGoing = false;
                        Console.WriteLine("Have a nice day!");
                    }
                }
            }
            else
            {
                while (menuGoing)
                {
                    int selectedOption = Menu.ShowMenu($"What do you want to do {character.Name}?\n", new[]
                    {
                        "Park Vehicle",
                        "Unpark Vehicle",
                        "Show parking history",
                         "Exit"
                    });
                    if (selectedOption == 0)
                    {
                        Parkingspot.Park(starship, character);
                    }
                    else if (selectedOption == 0)
                    {
                        Parkingspot.Unpark(starship, character);
                    }
                    else if (selectedOption == 1)
                    {

                    }
                    else
                    {
                        menuGoing = false;
                        Console.WriteLine("Have a nice day!");
                    }
                }
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
                peopleResponse = await SpaceORM.ValidateCharacter(input);
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
            List<Starship> ships = await SpaceORM.ValidateStarship(character.StarShips);
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
    }
}
