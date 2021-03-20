using System.Collections.Generic;
using System;
using RestSharp;


namespace SpacePort
{
   
        public class PersonData
        {
            public string Name { get; set; }          
            public string Gender { get; set; }          
            public List<string> Starships { get; set; }
        }

    public class PersonResponse
    {   
        public List<PersonData> Results { get; set; }
       
    }
}


    
