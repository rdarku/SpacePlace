using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpacePlace.Data
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset ModifiedAt { get; set; }

        public IEnumerable<Space> Spaces { get; set; }
    }
}