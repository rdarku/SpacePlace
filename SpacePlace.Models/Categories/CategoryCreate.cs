using System.ComponentModel.DataAnnotations;

namespace SpacePlace.Models.Categories
{
    public class CategoryCreate
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
