using RestSharp;
using SpaceParkModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpaceParkModel
{
    class SwPeople
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<Person> Results { get; set; }
    }
}