using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpacePlace.Data
{
    public class SpaceOwner
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SpaceOwnerId { get; set; }

        [Required]
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset ModifiedAt { get; set; }

        [ForeignKey(nameof(SpaceOwnerId))]
        public virtual ApplicationUser Owner { get; set; }
    }
}
