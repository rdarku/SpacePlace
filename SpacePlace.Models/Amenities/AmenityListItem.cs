using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePlace.Models.Amenities
{
    public class AmenityListItem
    {
        public int AmenityId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Date Created")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}
