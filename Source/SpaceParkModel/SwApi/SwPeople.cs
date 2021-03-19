using RestSharp;
using SpaceParkModel.Data;
using SpaceParkModel.SwApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpaceParkModel
{
    public class SwPeople
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<SwPeopleResult> Results { get; set; }
    }
}