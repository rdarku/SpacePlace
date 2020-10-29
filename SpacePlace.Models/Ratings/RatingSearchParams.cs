using System.ComponentModel.DataAnnotations;

namespace SpacePlace.Models.Ratings
{
    public class RatingSearchParams
    {
        [Required]
        public int SpaceId { get; set; }
    }
}
