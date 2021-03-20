using System;
using RestSharp;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpacePort
{
    class Program
    {
        static void Main(string[] args)
        {
            //   "people/?search=" + name, DataFormat.Json
            //MyContext context = new MyContext();
            //var order = new Order()
            //{
            //    CustomerID = 2,
            //    EmployeeID = 555,
            //    OrderDate = new DateTime(2021, 3, 15)
            //};
            //context.Add(order);
            //context.SaveChanges();

            //var client = new RestClient("https://swapi.dev/api/");
            //var request = new RestRequest("people/?search=Leia Organa", DataFormat.Json);

            //var peopleResponse = await client.GetAsync<PersonResponse>(request);

            //foreach (var item in peopleResponse.Results)
            //{
            //    Console.WriteLine(item.name);
            //}

            //APIFetch a = new APIFetch();
            //var result = a.GetPerson("Luke Skywalker");



            //foreach (var item in result.Starships)
            //{
            //    Console.WriteLine(item);
            //}

            StartMenu a = new StartMenu();
            a.ValidateName("Luke Skywalker");
            a.AddToDataBase();
           
            
            // a.Printint();
            Console.WriteLine();

            // APIFetch a = new APIFetch();
            //Console.WriteLine( a.GetSpaceShip(12).Name);


            Console.ReadKey();

        }
    }
}
