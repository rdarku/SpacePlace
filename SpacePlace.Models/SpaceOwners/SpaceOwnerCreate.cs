using System.ComponentModel.DataAnnotations;

namespace SpacePlace.Models.SpaceOwner
{
    public class SpaceOwnerCreate
    {
  
        [Required]
        public string SpaceOwnerId { get; set; }

    }
}
