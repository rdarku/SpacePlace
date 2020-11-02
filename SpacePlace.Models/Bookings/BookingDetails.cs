using System;

namespace SpacePlace.Models.Bookings
{
    public class BookingDetails
    {
        public int Id { get; set; }

        public int SpaceId { get; set; }

        public string Space { get; set; }

        public int RenterId { get; set; }

        public string Renter { get; set; }

        public string Status { get; set; }

        public DateTime BookingDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
