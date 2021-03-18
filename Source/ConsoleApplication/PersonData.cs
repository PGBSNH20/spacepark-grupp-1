using System.Collections.Generic;
using System;
using RestSharp;


namespace SpacePort
{
   
        public class PersonData
        {
           
            public string Name { get; set; }
            public string height { get; set; }
            public string mass { get; set; }
            public string hair_color { get; set; }
            public string skin_color { get; set; }
            public string eye_color { get; set; }
            public string birth_year { get; set; }
            public string gender { get; set; }
            public string homeworld { get; set; }
            public List<string> films { get; set; }
            public List<string> species { get; set; }
            public List<object> vehicles { get; set; }
            public List<object> starships { get; set; }
            public DateTime created { get; set; }
            public DateTime edited { get; set; }
            public string url { get; set; }
        }

    internal class PersonResponse
    {
        

        public List<PersonData> Results { get; set; }
       
    }
}


    
