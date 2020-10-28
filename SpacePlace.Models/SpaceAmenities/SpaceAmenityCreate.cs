using System.ComponentModel.DataAnnotations;

namespace SpacePlace.Models.SpaceAmenities
{
    public class SpaceAmenityCreate
    {
        [Required]
        public int SpaceId { get; set; }

        [Required]
        public int AmenityId { get; set; }
    }
}
