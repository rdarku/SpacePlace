using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpacePlace.Data
{
    public class Amenity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
       
        public string Description { get; set; }

        [Required]
        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset ModifitedAt { get; set; }

        public IEnumerable<SpaceAmenity> SpaceAmenities { get; set; }
    }
}
