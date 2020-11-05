using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePlace.Models.Bookings
{
    public class BookingListItem
    {
        public int BookingId { get; set; }

        public int SpaceId { get; set; }

        public int RenterId { get; set; }

        public string Duration { get; set; }

        public string DurationUnit { get; set; }

        [Display(Name ="Date Booked")]
        public DateTimeOffset BookingDate { get; set; }

        [Display(Name = "Start Time")]
        public DateTimeOffset StartDate { get; set; }

        [Display(Name = "End Time")]
        public DateTimeOffset EndDate { get; set; }
    }
}
