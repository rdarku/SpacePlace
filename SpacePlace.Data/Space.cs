using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SpacePlace.Data
{
    public class Space
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset ModifiedAt { get; set; }

        [Required]
        public int MaxOccupancy { get; set; }

        [Required]
        public bool Legal { get; set; }

        [Required]
        public string  OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public virtual ApplicationUser  SpaceOwner { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }

        public ICollection<SpaceAmenity> SpaceAmenities { get; set; }

        public IEnumerable<Rating> Ratings { get; set; }

        public double AverageCleanlinessRating
        {
            get
            {
                var totalScore = 0d;
                foreach (var rating in Ratings)
                {
                    totalScore += rating.CleanlinessRating;
                }

                return totalScore == 0 ? 0 : (totalScore / Ratings.Count());
            }
        }

        public double AverageEnvironmentRating
        {
            get
            {
                var totalScore = 0d;
                foreach (var rating in Ratings)
                {
                    totalScore += rating.EnvironmentRating;
                }

                return totalScore == 0 ? 0 : (totalScore / Ratings.Count());
            }
        }

        public double AverageResponsivenessRating
        {
            get
            {
                var totalScore = 0d;
                foreach (var rating in Ratings)
                {
                    totalScore += rating.ResponsivenessRating;
                }

                return totalScore == 0 ? 0 : (totalScore / Ratings.Count());
            }
        }

        public double AverageLuxuryRating
        {
            get
            {
                var totalScore = 0d;
                foreach (var rating in Ratings)
                {
                    totalScore += rating.LuxuryRating;
                }

                return totalScore == 0 ? 0 : (totalScore / Ratings.Count());
            }
        }

        public double AverageAccessibilityRating
        {
            get
            {
                var totalScore = 0d;
                foreach (var rating in Ratings)
                {
                    totalScore += rating.AccessibilityRating;
                }

                return totalScore == 0 ? 0 : (totalScore / Ratings.Count());
            }
        }
    }
}
