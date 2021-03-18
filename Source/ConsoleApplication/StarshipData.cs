using System.Collections.Generic;




namespace SpacePort

{
    public class StarshipData
    {
        public int StarshipID { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }

        
    }


    public class StarshipResponse
    {


        public List<StarshipData> Results { get; set; }


    }
}