using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceParkModel.Data
{
    public class PriceBreakPoint
    {
        // set the hours as ID, since they have to be unique
        [Key]
        public int Hours { get; set; }
        public decimal Price { get; set; }
    }
}
