using System;
using System.ComponentModel.DataAnnotations;

namespace SpacePlace.Models.Bookings
{
    public class BookingCreate
    {
        [Required]
        public int SpaceId { get; set; }

        [Required]
        public int RenterId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
