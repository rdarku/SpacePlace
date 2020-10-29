using SpacePlace.Data;
using SpacePlace.Models.Ratings;
using System;
using System.Collections.Generic;
using System.Linq;

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
                    AccessibilityRating = model.AccessibilityRating,
                    RenterId = model.RenterId,
                    SpaceId = model.SpaceId
                    
                    // missing renterID and SpaceID
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

        // get list of all ratings for ONE SPACE
        public IEnumerable<RatingListItem> GetAllRatings(RatingSearchParams model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Ratings
                    .Where(r => r.SpaceId == model.SpaceId)
                    .Select(r => new RatingListItem
                    {
                        SpaceId = r.  SpaceId,
                        Comments = r.Comments,
                        CleanlinessRating = r.CleanlinessRating,
                        EnvironmentRating = r.EnvironmentRating,
                        ResponsivenessRating = r.ResponsivenessRating,
                        LuxuryRating = r.LuxuryRating,
                        AccessibilityRating = r.AccessibilityRating,
                        RatingId = r.Id
                    }
                    ).ToList();
            }
        }
        //get one rating for one space? ???
        public RatingListItem GetRatingById(int id)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var foundRating = ctx.Ratings.Where(c => c.Id == id)
                        .FirstOrDefault();

                    return (foundRating != null) ?
                        new RatingListItem()
                        {
                            SpaceId = foundRating.SpaceId,
                            Comments = foundRating.Comments,
                            CleanlinessRating = foundRating.CleanlinessRating,
                            EnvironmentRating = foundRating.EnvironmentRating,
                            ResponsivenessRating = foundRating.ResponsivenessRating,
                            LuxuryRating = foundRating.LuxuryRating,
                            AccessibilityRating = foundRating.AccessibilityRating,
                            RatingId = foundRating.Id
                        }
                        : null;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
    
}
