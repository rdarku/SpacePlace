using SpacePlace.Data;
using SpacePlace.Models.Categories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.EntitySql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePlace.Services
{
    public class CategoryService
    {
        // create
        public bool CreateCategory(CategoryCreate model)
        {
            var newCategory = new Category
            {
                Name = model.Name,
                Description = model.Description,
                CreatedAt = DateTime.Now
            };

            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Categories.Add(newCategory);
                    return ctx.SaveChanges() == 1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        // read all
        public IEnumerable<CategoryListItem> GetAllCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Categories
                    .Select(c => new CategoryListItem
                    {
                        CategoryId = c.Id,
                        Name = c.Name,
                        Description = c.Description,
                        CreatedAt = c.CreatedAt
                    }
                    ).ToList();
            }
        }

        // read by ID

        // update

        // delete
    }
}
