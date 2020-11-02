using Sentry;
using SpacePlace.Data;
using SpacePlace.Data.Extensions;
using SpacePlace.Models.SpaceAmenities;
using SpacePlace.Models.Spaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SpacePlace.Services
{
    public class SpaceService
    {
        public bool CreateSpace(SpaceCreate model, string userID)
        {
            var newSpace = new Space { 
                CategoryId = model.CategoryId,
                OwnerId = userID,
                CreatedAt = DateTimeOffset.Now,
                Legal = model.Legal,
                Status = "vacant",
                MaxOccupancy = model.MaxOccupancy,
                Address = model.Address,
                Name = model.Name
            };

            try
            {
                using(var ctx = new ApplicationDbContext())
                {
                    ctx.Spaces.Add(newSpace);
                    return ctx.SaveChanges() == 1;
                }
            }
            catch(Exception e)
            {
                SentrySdk.CaptureException(e);
                return false;
            }
        }

        public IEnumerable<SpaceListItem> GetAllSpaces(SpaceSearchParams model)
        {
            try
            {
                using(var ctx = new ApplicationDbContext())
                {
                    var predicate = PredicateBuilder.True<Space>();

                    if (model.ShowByOwner && model.OwnerId != null)
                    {
                        predicate.And(s => s.OwnerId == model.OwnerId);
                    }

                    if (model.ShowOnlyVacant)
                        predicate.And(s => s.Status == "vacant");
                   
                   return ctx.Spaces
                        .Where(predicate)
                        .Select(s => new SpaceListItem
                        {
                            Category = s.Category.Name,
                            Status = s.Status,
                            CreatedAt = s.CreatedAt,
                            Id = s.Id,
                            Name = s.Name
                        }).ToList();
                }
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
                return null;
            }
        }

        public SpaceDetails GetSpaceById(int id)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var space = ctx.Spaces.Where(s => s.Id == id)
                        .Include( s => s.SpaceAmenities)
                        .Include(s => s.Ratings)
                        .FirstOrDefault();

                    if (space == null) return null;

                    return new SpaceDetails()
                    {
                        Id = space.Id,
                        Name = space.Name,
                        MaxOccupancy = space.MaxOccupancy,
                        Address = space.Address,
                        Owner = space.SpaceOwner.FullName,
                        Category = space.Category.Name,
                        Status  = space.Status,
                        CreatedAt = space.CreatedAt,
                        AverageAccessibilityRating = space.AverageAccessibilityRating,
                        AverageCleanlinessRating = space.AverageCleanlinessRating,
                        AverageEnvironmentRating = space.AverageEnvironmentRating,
                        AverageLuxuryRating = space.AverageLuxuryRating,
                        AverageResponsivenessRating = space.AverageResponsivenessRating,
                        SpaceAmenities = space.SpaceAmenities as ICollection<SpaceAmenityDetails>,
                        AmenityCount = space.SpaceAmenities.Count,
                        FirstAmenity = space.SpaceAmenities.First().Amenity.Name

                    };
                }
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
                return null;
            }
        }

        public bool UpdateSpace(SpaceEdit model)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var space = ctx.Spaces.Where(s => s.Id == model.Id)
                        .FirstOrDefault();

                    if (space == null) return false;

                    space.Address = model.Address;
                    space.CategoryId = model.CategoryId;
                    space.Legal = model.Legal;
                    space.MaxOccupancy = model.MaxOccupancy;
                    space.Name = model.Name;
                    space.Status = model.Status;

                    return ctx.SaveChanges() == 1;
                }
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
                return false;
            }
        }

        public bool ArchiveSpace(int id)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var space = ctx.Spaces.Where(s => s.Id == id)
                        .FirstOrDefault();
                    space.Status = "archived";
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
