using Sentry;
using SpacePlace.Data;
using SpacePlace.Models.Amenities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpacePlace.Services
{
    public class AmenityService
    {
        public bool CreateAmenity(AmenityCreate model)
        {
            var newAmenity = new Amenity
            {
                Name = model.Name,
                Description = model.Description,
                CreatedAt = DateTime.Now
            };

            try
            {
                using(var ctx = new ApplicationDbContext())
                {
                    ctx.Amenities.Add(newAmenity);
                    return ctx.SaveChanges() == 1;
                }
            }
            catch(Exception e)
            {
                SentrySdk.CaptureException(e);
                return false;
            }
                
        }

        public IEnumerable<AmenityListItem> GetAllAmenities()
        {
            using(var ctx = new ApplicationDbContext())
            {
                return ctx.Amenities
                    .Select(a => new AmenityListItem
                    {
                        AmenityId = a.Id,
                        Name = a.Name,
                        Description = a.Description,
                        CreatedAt = a.CreatedAt
                    }
                    ).ToList();
            }
        }

        public AmenityListItem GetAmenityById(int id)
        {
            try
            {
                using(var ctx = new ApplicationDbContext())
                {
                    var foundAmenity = ctx.Amenities.Where(a => a.Id == id)
                        .FirstOrDefault();

                    return (foundAmenity != null) ?
                        new AmenityListItem()
                        {
                            AmenityId = foundAmenity.Id,
                            Name = foundAmenity.Name,
                            Description = foundAmenity.Description,
                            CreatedAt = foundAmenity.CreatedAt
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

        public bool UpdateAmenity(AmenityEdit model)
        {
            try
            {
                using(var ctx = new ApplicationDbContext())
                {
                    var amenityEntity = ctx.Amenities.Where(a => a.Id == model.Id)
                        .FirstOrDefault();
                    if (amenityEntity == null)
                        return false;

                    amenityEntity.Name = model.Name;
                    amenityEntity.Description = model.Description;
                    amenityEntity.ModifitedAt = DateTimeOffset.UtcNow;

                    return ctx.SaveChanges() == 1;
                }
            }
            catch(Exception e)
            {
                SentrySdk.CaptureException(e);
                return false;
            }
        }

        public bool DeleteAmenity(int id)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var amenityEntity = ctx.Amenities.Where(a => a.Id == id)
                        .FirstOrDefault();
                    if (amenityEntity == null)
                        return false;

                    //check to make sure amenity is not linked to SpaceAmenities before deleting
                    if(amenityEntity.SpaceAmenities == null)
                    {
                        ctx.Amenities.Remove(amenityEntity);
                        return ctx.SaveChanges() == 1;
                    }
                    else
                    {
                        SentrySdk.CaptureMessage($"Cannot delete Amenity with ID:{id} because it is in use");
                    }
                    return false;
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
