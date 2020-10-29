using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [Range(0d, 5d)]
        public double CleanlinessRating { get; set; }

        [Required]
        [Range(0d, 5d)]
        public double EnvironmentRating { get; set; }

        [Required]
        [Range(0d, 5d)]
        public double ResponsivenessRating { get; set; }

        [Required]
        [Range(0d, 5d)]
        public double LuxuryRating { get; set; }

        [Required]
        [Range(0d, 5d)]
        public double AccessibilityRating { get; set; }
    }
}
