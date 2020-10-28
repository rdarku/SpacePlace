using System;

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
    }
}
