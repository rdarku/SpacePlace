using SpacePlace.Data;
using SpacePlace.Models.Amenities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace SpacePlace.Services
{
    public class AmenityService
    {
        //create
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
                Console.WriteLine(e.Message);
                return false;
            }
                
        }

        //read all
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

        //read by ID
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
                Console.WriteLine(e.Message);
                return null;
            }
        }

        //update
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
                Console.WriteLine(e.Message);
                return false;
            }
        }

        //delete
    }
}
