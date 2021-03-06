﻿using Sentry;
using SpacePlace.Data;
using SpacePlace.Models.SpaceOwner;
using SpacePlace.Models.SpaceOwners;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpacePlace.Services
{
    public class SpaceOwnerService
    {
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
                SentrySdk.CaptureException(e);
                return false;
            }
        }

        public IEnumerable<SpaceOwnerListItem> GetAllOwners()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.SpaceOwners
                    .Select(o => new SpaceOwnerListItem
                    {
                        Id = o.Id,
                        SpaceOwner = o.Owner.FullName,
                        CreatedAt = o.CreatedAt
                    }
                    ).ToList();
            }
        }
        public SpaceOwnerListItem GetOwnerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.SpaceOwners
                    .Where(r => r.Id == id)
                    .Select(r => new SpaceOwnerListItem()
                        {
                        Id = r.Id,
                        SpaceOwner = r.Owner.FullName,
                        CreatedAt = r.CreatedAt
                    })
                    .FirstOrDefault();
            }
        }

    }
}
