using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePlace.Models.Bookings
{
    public class BookingEdit
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int RenterId { get; set; }

        [Required]
        public int SpaceId { get; set; }

        [Required]
        public DateTime StartDate{get; set;}

        [Required]
        public DateTime EndDate { get; set; }
    }
}
