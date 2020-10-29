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
        public IEnumerable<BookingListItem> GetAllBookings()
        {
            using(var ctx = new ApplicationDbContext())
            {
                return ctx.Bookings
                    .Select(b => new BookingListItem
                    {
                        BookingId = b.Id,
                        SpaceId = b.SpaceId,
                        RenterId = b.RenterId,
                        
                        BookingDate = b.BookingDate,
                        StartDate = b.StartDate,
                        EndDate = b.EndDate
                    }
                    ).ToList();
            }
        }

        //read by ID
        public BookingListItem GetBookingById(int id)
        {
            try
            {
                using(var ctx = new ApplicationDbContext())
                {
                    var foundBooking = ctx.Bookings.Where(b => b.Id == id)
                        .FirstOrDefault();

                    return (foundBooking != null) ?
                        new BookingListItem()
                        {
                            BookingId = foundBooking.Id,
                            SpaceId = foundBooking.SpaceId,
                            RenterId = foundBooking.RenterId,
                            BookingDate = foundBooking.BookingDate,
                            StartDate = foundBooking.StartDate,
                            EndDate = foundBooking.EndDate
                        }
                        : null;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        //Update
        public bool UpdateBooking(BookingEdit model)
        {
            try
            {
                using(var ctx = new ApplicationDbContext())
                {
                    var bookingEntity = ctx.Bookings.Where(b => b.Id == model.Id)
                        .FirstOrDefault();

                    if (bookingEntity == null)
                        return false;

                    bookingEntity.Id = model.Id;
                    bookingEntity.RenterId = model.RenterId;
                    bookingEntity.SpaceId = model.SpaceId;
                    bookingEntity.StartDate = model.StartDate;
                    bookingEntity.EndDate = model.EndDate;

                    return ctx.SaveChanges() == 1;

                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        //Delete
        public bool DeleteBooking(int id) //We want to archive
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var bookingEntity = ctx.Bookings.Where(b => b.Id == id)
                        .FirstOrDefault();

                    if (bookingEntity == null)
                        return false;

                    
                    ctx.Bookings.Remove(bookingEntity);

                    return ctx.SaveChanges() == 1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
