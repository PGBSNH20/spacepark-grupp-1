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
            SwApi swApi = new SwApi();
            //var allStarships = swApi.GetAllReources<SwStarshipsResult>(SwApiResource.starships).Result;
            //var data = swApi.GetAllReources<SwPeopleResult>(SwApiResource.people).Result;
            var data = swApi.GetAllResources<SwStarshipsResult>(SwApiResource.starships).Result;
            //List<SwPeopleResult> peopleGeneric = swApi.GetResourcePage<SwPeopleResult>(SwApiResource.people).Result;
            //List<SwPeopleResult> searchedPerson = swApi.SearchPeople("Luke Skywalker").Result;
            ////List<SwStarshipsResult> starships = swApi.GetAllStarships().Result;
            ///
            foreach (var item in data)
            {
                Console.WriteLine(item.Name);
                //Console.WriteLine(item.Starships);
            }

            //GetResourcePage<SwPeopleResult>()

            Console.ReadKey();
        }
    }
}
