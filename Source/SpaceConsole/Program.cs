using System;

namespace SpaceConsole
{
    class Program
    {
        static async void Main(string[] args)
        {
            await SpaceEngine.SpaceOrm.GetPeople();
        }
    }
}
