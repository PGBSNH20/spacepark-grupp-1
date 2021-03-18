using System;
using RestSharp;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpacePort
{
    public class APIFetch
    {



        private static readonly RestClient client = new RestClient("https://swapi.dev/api/");
        public static async Task<IRestResponse> GetPersonResponse(string name)
        {
            var request = new RestRequest("people/?search=" + name, DataFormat.Json);
            var response = client.ExecuteAsync<PersonResponse>(request);

            return await response;
        }

        public static async Task<IRestResponse> GetSpaceshipResponse(string name)
        {
            var request = new RestRequest("starships/?search=" + name, DataFormat.Json);
            var response = client.ExecuteAsync<StarshipResponse>(request);

            return await response;
        }



        public static PersonData GetPerson(string name)
        {
            var dataResponse = GetPersonResponse(name);
            var data = JsonConvert.DeserializeObject<PersonResponse>(dataResponse.Result.Content);
            return data.Results[0];
        }

        public static StarshipData GetSpaceShip(string name)
        {
            var dataResponse = GetSpaceshipResponse(name);
            var data = JsonConvert.DeserializeObject<StarshipResponse>(dataResponse.Result.Content);

            return data.Results[0];
        }
    }
}
