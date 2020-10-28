using SpacePlace.Data;
using SpacePlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                CreatedAt= DateTime.Now
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

        //read by id

        //update

        //delete

    }
}
