using System;
using System.ComponentModel.DataAnnotations;

namespace SpacePlace.Models.SpaceOwners
{
    public class SpaceOwnerListItem
    {
        public int Id { get; set; }
        
        [Required]
        //create a string for the spaceowner name  
        [Display (Name="Owner Name")]
        public string SpaceOwner { get; set; }

        [Display(Name = "Date Created")]
        public DateTimeOffset CreatedAt { get; set; }

    }
}
