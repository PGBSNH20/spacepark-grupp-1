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
        public  async Task<IRestResponse> GetPersonResponse(string name)
        {
            try
            {
                var request = new RestRequest("people/?search=" + name, DataFormat.Json);
                var response = client.ExecuteAsync<PersonResponse>(request);

                return await response;
            }
            catch (Exception)
            {

                Console.WriteLine("User not found");
                return null;
            }            
        }

        public  async Task<IRestResponse> GetSpaceshipResponseByIndex(int number)
        {
            var request = new RestRequest("starships/"+ number+"/", DataFormat.Json);
            var response = client.ExecuteAsync<StarshipData>(request);

            return await response;
        }



        public  PersonData GetPerson(string name)
        {           
                var dataResponse = GetPersonResponse(name);
                var data = JsonConvert.DeserializeObject<PersonResponse>(dataResponse.Result.Content);
                return data.Results[0];                       
        }



        public StarshipData GetSpaceShip(int number)
        {
            var dataResponse = GetSpaceshipResponseByIndex(number);
            var data = JsonConvert.DeserializeObject<StarshipData>(dataResponse.Result.Content);

            return data;
        }
    }
}
