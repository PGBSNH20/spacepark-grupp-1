using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceParkModel.Data
{
    public class Occupancy
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public int SpaceshipID { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}
