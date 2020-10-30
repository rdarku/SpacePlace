using SpacePlace.Data;
using SpacePlace.Models.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpacePlace.Services
{
    public class BookingService
    {
        public bool CreateBooking(BookingCreate model)
        {
            var newBooking = new Booking
            {
                SpaceId = model.SpaceId,
                RenterId = model.RenterId,
                BookingDate = DateTime.Now,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Status = "booked"
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

        //get booking with amenities

        public Booking GetBookingByIdWithAmenities(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var booking = (from bo in ctx.Bookings
                               join am in ctx.Amenities on bo.Id equals am.Id
                               where bo.Id == id
                               select new Booking()
                               {
                                   Id = bo.Id,
                                   RenterId = bo.RenterId,
                                   Renter = bo.Renter,
                                   Space = bo.Space,
                                   SpaceId = bo.SpaceId,
                                   StartDate = bo.StartDate,
                                   Status = bo.Status
                               }).FirstOrDefault();
        
                return booking;
            }
        }

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

        public bool CancelBooking(int id)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var bookingEntity = ctx.Bookings.Where(b => b.Id == id)
                        .FirstOrDefault();

                    if (bookingEntity == null)
                        return false;


                    bookingEntity.Status = "Cancel";

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
