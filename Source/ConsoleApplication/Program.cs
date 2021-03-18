using System;
using RestSharp;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpacePort
{
    class Program
    {
        static async Task Main(string[] args)
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
           
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest("people/?search=Leia Organa", DataFormat.Json);
            
            var peopleResponse = await client.GetAsync<PersonResponse>(request);

            foreach (var item in peopleResponse.Results)
            {
                Console.WriteLine(item.birth_year);
            }
          

            //foreach (var item in peopleResponse.Starships)
            //{
            //    Console.WriteLine(item);
            //}
            //foreach (var item in peopleResponse.Starship)
            //{
            //    Console.WriteLine(item);
            //}


            //foreach (var p in peopleResponse.Name)
            //{
            //    Console.WriteLine(p);
            //    //Id.Add(p.Url);

            //}

            Console.WriteLine();
            Console.ReadKey();

        }
    }
}
