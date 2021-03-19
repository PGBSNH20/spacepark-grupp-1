using SpaceParkModel.Data;
using System;
using System.Collections.Generic;

namespace SpaceParkConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            SwApi peopleApi = new SwApi();
            List<Person> people = peopleApi.GetPeople().Result;
            Console.ReadKey();
        }
    }
}
