using System.ComponentModel.DataAnnotations;

namespace SpacePlace.Models.SpaceAmenities
{
    public class SpaceAmenityListItem
    {
        public string Id { get; set; }

        [Display(Name ="Space Name")]
        public string SpaceName { get; set; }

        [Display(Name = "Amenity Name")]
        public string AmenityName { get; set; }

    }
}
