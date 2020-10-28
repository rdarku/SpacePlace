using SpacePlace.Data;
using SpacePlace.Models.Ratings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePlace.Services
{
    public class RatingService
    {

            public bool CreateRating(RatingCreate model)
            {
                var newRating = new Rating
                {
                    Comments = model.Comments,
                    CleanlinessRating = model.CleanlinessRating,
                    EnvironmentRating = model.EnvironmentRating,
                    ResponsivenessRating = model.ResponsivenessRating,
                    LuxuryRating = model.LuxuryRating,
                    AccessibilityRating = model.AccessibilityRating

                };

                try
                {
                    using (var ctx = new ApplicationDbContext())
                    {
                        ctx.Ratings.Add(newRating);

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
