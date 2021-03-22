using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceEngine
{
    public class Parkingspot
    {
        [Key]
        public int ID { get; set; }
        public int MinSize { get; set; }
        public int MaxSize { get; set; }
        public string CharacterName { get; set; }
        public string SpaceshipName { get; set; }

        //public Parkingspot(int id, int minSize, int maxSize)
        //{
        //    ID = id; 
        //    MinSize = minSize;
        //    MaxSize = maxSize;
        //}
    }
}
