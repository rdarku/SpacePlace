namespace SpacePlace.Models.Spaces
{
    public class SpaceSearchParams
    {
        public bool ShowByOwner { get; set; } = false;

        public string OwnerId { get; set; }

        public bool ShowOnlyVacant { get; set; } = false;
    }
}
