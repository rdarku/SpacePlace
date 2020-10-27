using System;
using System.ComponentModel.DataAnnotations;

namespace SpacePlace.Data
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name{ get; set; }

        public string Description { get; set; }

        [Required]
        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset ModifiedAt { get; set; }
    }
}
