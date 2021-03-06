﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpacePlace.Data
{
    public class Renter
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset ModifiedAt { get; set; }

        [Required]
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string RenterId { get; set; }

        [ForeignKey(nameof(RenterId))]
        public virtual ApplicationUser RenterUser { get; set; }
    }
}
