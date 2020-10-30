using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SpacePlace.Data
{
    public class Category
    {
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public Category()
        {
            Spaces = new HashSet<Space>();
        }

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

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Space> Spaces { get; set; }
    }
}