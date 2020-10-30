using System.ComponentModel.DataAnnotations;

namespace SpacePlace.Models.SpaceAmenities
{
    public class SpaceAmenityEdit
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public int SpaceId { get; set; }

        [Required]
        public int AmenityId { get; set; }
    }
}
