using SpacePlace.Models.SpaceAmenities;
using System;
using System.Collections.Generic;

namespace SpacePlace.Models.Spaces
{
    public class SpaceDetails
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public string Category { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public string Address { get; set; }

        public string Owner { get; set; }

        public int MaxOccupancy { get; set; }

        public double AverageCleanlinessRating { get; set; }

        public double AverageEnvironmentRating { get; set; }

        public double AverageResponsivenessRating { get; set; }

        public double AverageLuxuryRating { get; set; }

        public double AverageAccessibilityRating { get; set; }

        public ICollection<SpaceAmenityDetails> SpaceAmenities { get; set; }
    }
}
