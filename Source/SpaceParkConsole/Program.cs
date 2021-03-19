using SpaceParkModel.Data;
using System;

namespace SpaceParkConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            SwApi peopleApi = new SwApi();
            peopleApi.GetPeople();
            Console.ReadKey();
        }
    }
}
