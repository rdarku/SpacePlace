using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
