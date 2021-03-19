using RestSharp;
using System;
using System.Threading.Tasks;

namespace SpaceEngine
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.Write("Enter your name: ");
            string input = Console.ReadLine();
            await SpaceOrm.ValidateCharacter(input);
        }
    }
}
