using System.ComponentModel.DataAnnotations;

namespace SpaceEngine
{
    public class Starship
    {
        [Key]
        public string Name { get; set; }
        public string Model { get; set; }
        public string Length { get; set; }
    }
}