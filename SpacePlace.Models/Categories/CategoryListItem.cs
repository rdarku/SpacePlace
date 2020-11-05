using System;
using System.ComponentModel.DataAnnotations;

namespace SpacePlace.Models.Categories
{
    public class CategoryListItem
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name="Date Created")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}
