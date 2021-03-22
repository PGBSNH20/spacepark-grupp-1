using SpaceParkModel.Data;
using SpaceParkModel.SwApi;
using System;
using System.Collections.Generic;

namespace SpaceParkConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            bool isValidName = menu.PromptName();
            //if (isValidName)
            //{
            //    menu.MainMenu();
            //}
            Environment.Exit(0);
        }
    }
}
