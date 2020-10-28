using System.ComponentModel.DataAnnotations;

namespace SpacePlace.Models.Amenities
{
    public class AmenityCreate
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
