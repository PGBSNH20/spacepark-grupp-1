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

            PersonData a = new PersonData();
            a=APIFetch.GetPerson("Luke Skywalker");
            Console.WriteLine(a.Name);

            Console.WriteLine();
           
            
            Console.ReadKey();

        }
    }
}
