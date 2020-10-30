using SpacePlace.Data;
using SpacePlace.Models.Renters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpacePlace.Services
{
    public class RenterService
    {
        public bool CreateRenter(RenterCreate model)
        {
            var newrenter = new Renter()
            {
                RenterId = model.RenterID,
                CreatedAt= DateTimeOffset.Now
            };

            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Renters.Add(newrenter);
                    return ctx.SaveChanges() == 1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public IEnumerable<RenterListItem> GetAllRenters()
        {
            using (var ctx = new ApplicationDbContext())
            { 
                return ctx.Renters
                    .Select(c => new RenterListItem
                    {
                        Id = c.Id,
                        Renter = c.RenterUser.FullName,
                        CreatedAt = c.CreatedAt
                    }
                    ).ToList();
            }
        }

    }
}
