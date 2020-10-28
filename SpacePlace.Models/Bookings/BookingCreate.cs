using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePlace.Models.Bookings
{
    public class BookingCreate
    {
        [Required]
        public int SpaceId { get; set; }

        [Required]
        public int RenterId { get; set; }

        [Required]//Do we want a range on this?
        public int Duration { get; set; }

        [Required]
        public string DurationUnit { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
