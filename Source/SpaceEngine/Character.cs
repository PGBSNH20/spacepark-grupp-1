using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SpaceEngine
{
    public class Character
    {
        [Key]
        public string Name { get; set; }
        public int Height { get; set; }
        public string Gender { get; set; }
        public List<string> StarShips { get; set; }
    }
}
