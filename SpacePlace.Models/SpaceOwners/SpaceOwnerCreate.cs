using SpacePlace.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpacePlace.Models.SpaceOwner
{
    public class SpaceOwnerCreate
    {
  
        [Required]
        public int SpaceOwnerId { get; set; }

    }
}
