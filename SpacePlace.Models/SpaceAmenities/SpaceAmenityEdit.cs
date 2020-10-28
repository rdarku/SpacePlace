using System.ComponentModel.DataAnnotations;

namespace SpacePlace.Models.SpaceAmenities
{
    public class SpaceAmenityEdit
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int SpaceId { get; set; }

        [Required]
        public int AmenityId { get; set; }
    }
}
