using Sentry;
using SpacePlace.Data;
using SpacePlace.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpacePlace.Services
{
    public class CategoryService
    {
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
                SentrySdk.CaptureException(e);
                return false;
            }
        }

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

        public CategoryListItem GetCategoryById(int id)
        {
            try
            {
                using(var ctx = new ApplicationDbContext())
                {
                    var foundCategory = ctx.Categories.Where(c => c.Id == id)
                        .FirstOrDefault();
                    return (foundCategory != null) ?
                        new CategoryListItem() { 
                            CategoryId = foundCategory.Id,
                            Name = foundCategory.Name,
                            Description = foundCategory.Description,
                            CreatedAt = foundCategory.CreatedAt
                        }
                        : null;
                }
            }
            catch(Exception e)
            {
                SentrySdk.CaptureException(e);
                return null;
            }
        }

        public bool UpdateCategory(CategoryEdit model)
        {
            try
            {
                using(var ctx = new ApplicationDbContext())
                {
                    var categoryEntity = ctx.Categories.Where(c => c.Id == model.Id)
                        .FirstOrDefault();
                    if (categoryEntity == null)
                        return false;

                    categoryEntity.Name = model.Name;
                    categoryEntity.Description = model.Description;
                    categoryEntity.ModifiedAt = DateTimeOffset.UtcNow;

                    return ctx.SaveChanges() == 1;
                }
            }
            catch(Exception e)
            {
                SentrySdk.CaptureException(e);
                return false;
            }
        }

        public bool DeleteCategory(int id)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var categoryEntity = ctx.Categories.Where(c => c.Id == id)
                        .FirstOrDefault();
                    if (categoryEntity == null)
                        return false;

                    // make sure this category is not linked to any space before deleting
                    if(categoryEntity.Spaces == null)
                    {
                        ctx.Categories.Remove(categoryEntity);
                        return ctx.SaveChanges() == 1;
                    }
                    else
                    {
                        SentrySdk.CaptureMessage($"Cannot delete Category with ID:{id} because it is in use");
                    }

                    return false;
                }
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
                return false;
            }
        }
    }
}
