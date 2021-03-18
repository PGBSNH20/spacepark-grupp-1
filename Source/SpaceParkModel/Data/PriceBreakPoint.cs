using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceParkModel.Data
{
    class PriceBreakPoint
    {
        // set the hours as ID, since they have to be unique
        public int Hours { get; set; }
        public decimal Price { get; set; }
    }
}
