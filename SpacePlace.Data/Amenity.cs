using System;
using System.ComponentModel.DataAnnotations;

namespace SpacePlace.Data
{
    public class Amenity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
       
        public string Description { get; set; }

        [Required]
        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset ModifitedAt { get; set; }
    }
}
