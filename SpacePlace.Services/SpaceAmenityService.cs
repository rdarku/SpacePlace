using Sentry;
using SpacePlace.Data;
using SpacePlace.Models.SpaceAmenities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpacePlace.Services
{
    public class SpaceAmenityService
    {
        public bool CreateSpaceAmenity(SpaceAmenityCreate model)
        {
            var newSpaceAmenity = new SpaceAmenity
            {
                AmenityId = model.AmenityId,
                CreatedAt = DateTimeOffset.Now,
                SpaceId = model.SpaceId
            };

            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    ctx.SpaceAmenities.Add(newSpaceAmenity);

                    return ctx.SaveChanges() == 1;
                }
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
                return false;
            }
        }

        public IEnumerable<SpaceAmenityListItem> GetAllSpaceAmmenities()
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    return ctx.SpaceAmenities
                        .Select(s => new SpaceAmenityListItem
                        {
                            Id = s.Id,
                            AmenityName = s.Amenity.Name,
                            SpaceName = s.Space.Name
                        }).ToList();
                }
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
                return null;
            }
        }

        public SpaceAmenityDetails GetSpaceAmenityById(int id)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var spaceAmenity = ctx.SpaceAmenities
                        .Where(s => s.Id == id)
                        .FirstOrDefault();

                    if (spaceAmenity == null) return null;

                    return new SpaceAmenityDetails()
                    {
                        Id = spaceAmenity.Id,
                        AmenityId = spaceAmenity.AmenityId,
                        AmenityName = spaceAmenity.Amenity.Name,
                        Description = spaceAmenity.Amenity.Description,
                        SpaceId = spaceAmenity.SpaceId,
                        SpaceName = spaceAmenity.Space.Name
                    };
                }
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
                return null;
            }
        }

        public bool UpdateSpaceAmenity(SpaceAmenityEdit model)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var spaceAmenity = ctx.SpaceAmenities
                        .Where(s => s.SpaceId == model.SpaceId && s.AmenityId == model.AmenityId)
                        .FirstOrDefault();

                    if (spaceAmenity == null) return false;

                    spaceAmenity.SpaceId = model.SpaceId;
                    spaceAmenity.AmenityId = model.AmenityId;

                    return ctx.SaveChanges() == 1;
                }
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
                return false;
            }
        }

        public bool DeleteSpaceAmenity(int id)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var spaceAmenity = ctx.SpaceAmenities
                        .Where(s => s.Id == id)
                        .FirstOrDefault();

                    ctx.SpaceAmenities.Remove(spaceAmenity);

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
