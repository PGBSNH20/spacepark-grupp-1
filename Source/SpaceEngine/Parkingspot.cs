using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceEngine
{
    public class Parkingspot
    {
        public class Parkingslot
        {
            public DateTime Arrival { get; set; }
            public DateTime Departure { get; set; }
            public Starship Starship { get; set; }
        }

        public class Small : Parkingslot
        {
            public readonly int minSize = 0;
            public readonly int maxSize = 1000;
            public readonly int hourPrice = 1000;
        }

        public class Medium : Parkingslot
        {
            public readonly int minSize = 1001;
            public readonly int maxSize = 5000;
            public readonly int hourPrice = 2000;
        }

        public class Large : Parkingslot
        {
            public readonly int minSize = 5001;
            public readonly int maxSize = 100000;
            public readonly int hourPrice = 3000;
        }

        //TODO: Solve this later if needed.
        //public class DeathStar : Parkingslot
        //{
        //    public readonly int minSize = 119999;
        //    public readonly int maxSize = 120000;
        //    public readonly int hourPrice = 10000;
        //}
    }
}
