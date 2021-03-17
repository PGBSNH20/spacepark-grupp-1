using System;
using SpaceEngine;

namespace SpaceConsole
{
    class Program
    {
        static async void Main(string[] args)
        {
            //await SpaceOrm.GetPeople();
            await SpaceOrm.GetStarShips();
        }
    }
}
