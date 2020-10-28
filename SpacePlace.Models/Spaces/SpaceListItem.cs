using System;

namespace SpacePlace.Models.Spaces
{
    public class SpaceListItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public string Category { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
