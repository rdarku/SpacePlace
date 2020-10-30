using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpacePlace.Data
{
    public class SpaceAmenity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [Index("SpaceIdAndAmenityID",IsUnique =true, Order = 1)]
        public int SpaceId { get; set; }

        [ForeignKey(nameof(SpaceId))]
        public virtual Space Space { get; set; }

        [Required]
        [Index("SpaceIdAndAmenityID", IsUnique = true, Order = 2)]
        public int AmenityId { get; set; }

        [ForeignKey(nameof(AmenityId))]
        public virtual Amenity Amenity { get; set; }

        [Required]
        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset ModifiedAt { get; set; }
    }
}
