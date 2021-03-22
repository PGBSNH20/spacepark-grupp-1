using SpaceParkModel;
using SpaceParkModel.Data;
using SpaceParkModel.SwApi;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new();

            bool isValidName = menu.ShowNamePrompt();
            if (isValidName)
            {
                Console.WriteLine($"Welcome to SpacePark {menu.ActivePerson}, what would you like to do?");
                menu.MainMenu();
            }
            Environment.Exit(0);

            // Todo: check when you enter name {Luke (with a space)} fix that bug
        }
    }
}
