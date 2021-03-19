using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceParkModel.Data
{
    public class SwApi
    {
        RestClient client;

        public SwApi()
        {
            client = new RestClient("https://swapi.dev/api/");
        }

        public async Task<List<Person>> GetPeople()
        {
            var request = new RestRequest("people/", DataFormat.Json);
            var peopleResponse = await client.GetAsync<SwPeople>(request);
            List<Person> people = peopleResponse.Results; 
            return people;
        }
    }
}