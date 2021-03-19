using RestSharp;
using RestSharp.Authenticators;
using SpaceParkModel.SwApi;
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

        //public async Task<List<T>> GetResourcePage<T>(SwApiResource resource)
        //{
        //    string resourceString = resource.ToString();
        //    var request = new RestRequest($"{resourceString}/", DataFormat.Json);
        //    var response = await client.GetAsync<SwResource<T>>(request);
        //    List<T> datas = response.Results;
        //    return datas;
        //}

        public async Task<List<T>> GetAllResources<T>(SwApiResource resource)
        {
            SwResource<T> response = await GetResourcePage<T>(resource);
            List<T> datas = response.Results;
            // once it goes into the while loop, it uses the GetResourcePage(string) method 
            while (response.Next != null)
            {
                //request = new RestRequest(response.Next, DataFormat.Json);
                response = await GetResourcePage<T>(response.Next);
                datas.AddRange(response.Results);
            }
            return datas;
        }

        private async Task<SwResource<T>> GetResourcePage<T>(SwApiResource resource)
        {
            string resourceString = resource.ToString();
            var request = new RestRequest($"{resourceString}/", DataFormat.Json);
            return await client.GetAsync<SwResource<T>>(request);
        }

        private async Task<SwResource<T>> GetResourcePage<T>(string resource)
        {
            var request = new RestRequest(resource, DataFormat.Json);
            return await client.GetAsync<SwResource<T>>(request);
        }

        public async Task<List<SwPeopleResult>> SearchPeople(string searchTerm)
        {
            var request = new RestRequest($"people/?search={searchTerm}", DataFormat.Json);
            var response = await client.GetAsync<SwPeople>(request);
            List<SwPeopleResult> people = response.Results;
            return people;
        }

        //public async Task<List<SwPeopleResult>> GetPeople()
        //{
        //    var request = new RestRequest("people/", DataFormat.Json);
        //    var response = await client.GetAsync<SwPeople>(request);
        //    List<SwPeopleResult> people = response.Results;
        //    return people;
        //}

        //public async Task<List<SwPeopleResult>> SearchPeople(string searchTerm)
        //{
        //    var request = new RestRequest($"people/?search={searchTerm}", DataFormat.Json);
        //    var response = await client.GetAsync<SwPeople>(request);
        //    List<SwPeopleResult> people = response.Results;
        //    return people;
        //}

        //public async Task<List<SwStarshipsResult>> GetStarship()
        //{
        //    var request = new RestRequest("starships/", DataFormat.Json);
        //    var response = await client.GetAsync<SwStarships>(request);
        //    List<SwStarshipsResult> starships = response.Results;
        //    return starships;
        //}

        //public async Task<List<SwStarshipsResult>> GetAllStarships()
        //{
        //    var request = new RestRequest("starships/", DataFormat.Json);
        //    var response = await client.GetAsync<SwStarships>(request);
        //    List<SwStarshipsResult> starships = response.Results;
        //    // you want to load All the starships (instead of just 10)
        //    while (response.Next != null)
        //    {
        //        request = new RestRequest(response.Next, DataFormat.Json);
        //        response = await client.GetAsync<SwStarships>(request);
        //        starships.AddRange(response.Results);
        //    }
        //    return starships;
        //}
    }
}