using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceParkModel.Data
{
    class Occupancy
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public int SpaceshipID { get; set; }
        // if we arent putting Payment ...
        public bool HasPaid { get; set; }
        public DateTime ArrivalTime { get; set; }
        // are we leaving the entry in the database? or leave it and mark it as finished
        public bool HasLeft { get; set; }
    }
}
