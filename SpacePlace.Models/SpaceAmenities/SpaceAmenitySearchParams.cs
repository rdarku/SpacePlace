using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePlace.Models.SpaceAmenities
{
    public class SpaceAmenitySearchParams
    {
        [Required]
        public int SpaceId { get; set; }
        [Required]
        public int AmenityId { get; set; }
    }
}
