using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpacePlace.Data
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SpaceId { get; set; }
        [ForeignKey(nameof(SpaceId))] 
        public virtual Space Space { get; set; }

        [Required]
        public int RenterId { get; set; }
        [ForeignKey(nameof(RenterId))]
        public virtual Renter Renter { get; set; }

        public string Comments { get; set; }

        [Required]
        [Range(0, 5)]
        public int CleanlinessRating { get; set; }

        [Required]
        [Range(0, 5)]
        public int EnvironmentRating { get; set; }

        [Required]
        [Range(0, 5)]
        public int ResponsivenessRating { get; set; }

        [Required]
        [Range(0, 5)]
        public int LuxuryRating { get; set; }

        [Required]
        [Range(0, 5)]
        public int AccessibilityRating { get; set; }

    }
}
