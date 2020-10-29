using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpacePlace.Data
{
    public class SpaceAmenity
    {

        [Required]
        public int SpaceId { get; set; }

        [ForeignKey(nameof(SpaceId))]
        public virtual Space Space { get; set; }

        [Required]
        public int AmenityId { get; set; }

        [ForeignKey(nameof(AmenityId))]
        public virtual Amenity Amenity { get; set; }

        [Required]
        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset ModifiedAt { get; set; }
    }
}
