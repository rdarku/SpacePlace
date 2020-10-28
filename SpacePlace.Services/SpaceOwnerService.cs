using SpacePlace.Data;
using SpacePlace.Models.SpaceOwner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePlace.Services
{
    public class SpaceOwnerService
    {
        //create
        public bool CreateSpaceOwner(SpaceOwnerCreate model)
        {
            var newSpaceOwner = new SpaceOwner()
            {
                SpaceOwnerId = model.SpaceOwnerId,
                CreatedAt = DateTimeOffset.Now
            };

            try
            {
                using(var ctx = new ApplicationDbContext())
                {
                    ctx.SpaceOwners.Add(newSpaceOwner);
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

        //read by ID

        //update

    }
}
