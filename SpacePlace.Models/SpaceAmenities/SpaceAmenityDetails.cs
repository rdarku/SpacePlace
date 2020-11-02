using System;
using System.ComponentModel.DataAnnotations;

namespace SpacePlace.Models.SpaceAmenities
{
    public class SpaceAmenityDetails
    {
        public int Id { get; set; }

        [Required]
        public int SpaceId { get; set; }

        [Display(Name = "Space Name")]
        public string SpaceName { get; set; }

        [Required]
        public int AmenityId { get; set; }

        [Display(Name = "Amenity Name")]
        public string AmenityName { get; set; }

        public string Description { get; set; }
    }
}
