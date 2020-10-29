using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePlace.Models.Bookings
{
    public class BookingDetails
    {
        public int Id { get; set; }

        public int SpaceId { get; set; }

        public int RenterId { get; set; }

        public int Duration { get; set; }

        public string DurationUnit { get; set; }

        public string Stauts { get; set; }

        public DateTime BookingDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
