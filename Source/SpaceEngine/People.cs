using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SpaceEngine
{
    public class People
    {
        public int ID { get; set; }
        public string Name { get; set; }
        //public int Height { get; set; }
        public string Gender { get; set; }
    }
}
