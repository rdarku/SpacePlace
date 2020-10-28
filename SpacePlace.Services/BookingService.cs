using SpacePlace.Data;
using SpacePlace.Models.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePlace.Services
{
    public class BookingService
    {
        //create
        public bool CreateBooking(BookingCreate model)
        {
            var newBooking = new Booking
            {
                SpaceId = model.SpaceId,
                RenterId = model.RenterId,
                Duration = model.Duration,
                DurationUnit = model.DurationUnit,
                BookingDate = DateTime.Now,
                StartDate = model.StartDate,
                EndDate = model.EndDate
            };

            try
            {
                using(var ctx = new ApplicationDbContext())
                {
                    ctx.Bookings.Add(newBooking);
                    return ctx.SaveChanges() == 1;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }

        //read all

        //read by ID

        //Update

        //Delete
    }
}
