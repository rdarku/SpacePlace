using System.ComponentModel.DataAnnotations;

namespace SpacePlace.Models.Spaces
{
    public class SpaceEdit
    {   
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Range(1, 1000)]
        public int MaxOccupancy { get; set; }

        [Required]
        public bool Legal { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
