using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpacePlace.Data
{
    public class Renter
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset ModifiedAt { get; set; }

        [Required]
        public int RenterId { get; set; }

        [ForeignKey(nameof(RenterId))]
        public virtual ApplicationUser RenterUser { get; set; }
    }
}
