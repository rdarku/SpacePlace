using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePlace.Models.Ratings
{
    public class RatingListItem
    {
        public int SpaceId { get; set; }

        public string Comments { get; set; }

        public double CleanlinessRating { get; set; }

        public double EnvironmentRating { get; set; }

        public double ResponsivenessRating { get; set; }

        public double LuxuryRating { get; set; }

        public double AccessibilityRating { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
