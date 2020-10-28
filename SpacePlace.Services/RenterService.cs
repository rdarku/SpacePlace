using SpacePlace.Data;
using SpacePlace.Models;
using SpacePlace.Models.Renters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace SpacePlace.Services
{
    public class RenterService
    {
        //create
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

        //read all
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


        //read by id

        //update

        //delete

    }
}
