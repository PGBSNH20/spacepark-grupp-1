using SpaceParkModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceParkModel.SwApi
{
    public class SwStarships
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<SwStarshipsResult> Results { get; set; }
    }
}
