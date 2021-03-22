using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SpacePort
{
    public class Person
    {

        [Key]
        public int ID { get; set; }
        public int PersonID { get; set; }
        public string Name { get; set; }        
        public int StarshipID { get; set; }




    }
}
