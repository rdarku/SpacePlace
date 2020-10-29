using SpacePlace.Data;
using SpacePlace.Models.Spaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePlace.Services
{
    public class SpaceService
    {
        private readonly string _userId;

        public SpaceService(string userId)
        {
            _userId = userId;
        }

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
                Console.WriteLine(e.Message);
                return false;
            }
        }

        // need to add perspectives to this so we can get spaces for a particular owner
        public IEnumerable<SpaceListItem> GetAllSpaces(SpaceSearchParams model)
        {
            try
            {
                using(var ctx = new ApplicationDbContext())
                {
                    var query = ctx.Spaces;
                    if (model.ShowByOwner && model.OwnerId != null)
                    {
                        query.Where(s => s.OwnerId == model.OwnerId);
                    }

                    if (model.ShowOnlyVacant)
                        query.Where(s => s.Status == "vacant");
                   

                   return query
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
                Console.WriteLine(e.Message);
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
                        CreatedAt = space.CreatedAt
                    };
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
                Console.WriteLine(e.Message);
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
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
