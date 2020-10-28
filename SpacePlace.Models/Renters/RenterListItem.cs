using System;
using System.ComponentModel.DataAnnotations;

namespace SpacePlace.Models.Renters
{
    public class RenterListItem
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Renter")]
        public string Renter { get; set; }

        [Display(Name = "Date Created")]
        public DateTimeOffset CreatedAt { get; set; }

    }
}
