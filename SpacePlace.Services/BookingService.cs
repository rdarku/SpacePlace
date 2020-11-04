using AutoMapper;
using Sentry;
using SpacePlace.Data;
using SpacePlace.Models.Bookings;
using SpacePlace.Models.SpaceAmenities;
using SpacePlace.Models.Spaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SpacePlace.Services
{
    public class BookingService
    {
        private readonly IMapper _mapper;

        public BookingService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SpaceAmenity, SpaceAmenityDetails>()
                .ForMember(s => s.AmenityName, opt => opt.MapFrom(m => m.Amenity.Name))
                .ForMember(s => s.SpaceName, opt => opt.MapFrom(m => m.Space.Name))
                .ReverseMap();

                cfg.CreateMap<Space, SpaceDetails>()
                .ForMember(s => s.Category, opt => opt.MapFrom(m => m.Category.Name))
                .ForMember(s => s.Owner, opt => opt.MapFrom(m => m.SpaceOwner.FullName))
                .ReverseMap();
            });

            _mapper = config.CreateMapper();
        }

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
                SentrySdk.CaptureException(e);
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

        public BookingDetails GetBookingById(int id)
        {
            try
            {
                using(var ctx = new ApplicationDbContext())
                {
                    var foundBooking = ctx.Bookings
                        .Where(b => b.Id == id)
                        .Include(b => b.Space)
                        .Include(sA => sA.Space.SpaceAmenities)
                        .FirstOrDefault();

                    return (foundBooking != null) ?
                        new BookingDetails()
                        {
                            Id = foundBooking.Id,
                            SpaceId = foundBooking.SpaceId,
                            Space = _mapper.Map<SpaceDetails>(foundBooking.Space),
                            RenterId = foundBooking.RenterId,
                            Renter = foundBooking.Renter.RenterUser.FullName,
                            BookingDate = foundBooking.BookingDate,
                            StartDate = foundBooking.StartDate,
                            EndDate = foundBooking.EndDate,
                            Status = foundBooking.Status
                        }
                        : null;
                }
            }
            catch(Exception e)
            {
                SentrySdk.CaptureException(e);
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
                SentrySdk.CaptureException(e);
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
                SentrySdk.CaptureException(e);
                return false;
            }
        }
    }
}
