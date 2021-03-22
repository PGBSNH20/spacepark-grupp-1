using SpaceParkModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceParkConsole
{
    class Menu
    {
        SwApi swApi;
        public string ActivePerson { get; set; }

        public Menu()
        {
            swApi = new SwApi();
        }

        public int Show(string prompt, string[] options)
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
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine("- " + option);
                    Console.ResetColor();
                }

                // Read another key and adjust the selected value before looping to repeat all of this.
                key = Console.ReadKey().Key;
                if (key == ConsoleKey.DownArrow)
                {
                    selected = Math.Min(selected + 1, options.Length - 1);
                }
                else if (key == ConsoleKey.UpArrow)
                {
                    selected = Math.Max(selected - 1, 0);
                }
            }

            // Reset the cursor and return the selected option.
            Console.CursorVisible = true;
            return selected;
        }

        public bool PromptName()
        {
            Console.WriteLine("Please enter your name: ");
            string nameAnswer = Console.ReadLine();
            bool isSwChar = swApi.ValidateSwName(nameAnswer);
            if (isSwChar)
            {
                ActivePerson = nameAnswer;
                return true;
            }

            string[] options = { "Re-enter name ", "Quit" };
            int selection = Show("Sorry, looks like you entered an invalid name... what would you like to do?", options);
            if (selection == 0)
            {
                PromptName();
            }

            //Environment.Exit(0);
            return false;
            // check if person is valid *
            // if person is valid => store the name *
            //  => then return true *
            // if person is invalid => then what?
            //  => give option to reenter name and/or quit?
            //  => return false *
            // what do we return? the name or booleans? => bool * 

        }

        public void MainMenu()
        {
            string[] options = { "Do you want to park? ", "Pay and leave", "Quit" };
            int selection = 0;

            while (selection != options.Length - 1)
            {
                selection = Show("Welcome to SpacePark, what would you like to do?", options);
                switch (selection)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
