using System.ComponentModel.DataAnnotations;

namespace SpacePlace.Models.Ratings
{
    public class RatingCreate
    {
        [Required]
        public int SpaceId { get; set; }

        [Required]
        public int RenterId { get; set; }

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
