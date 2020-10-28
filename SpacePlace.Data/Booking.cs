using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SpacePlace.Data
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SpaceId { get; set; }
        [ForeignKey(nameof(SpaceId))]
        public virtual Space Space { get; set; }

        [Required]
        public int RenterId { get; set; }
        [ForeignKey(nameof(RenterId))]
        public virtual Renter Renter { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public string DurationUnit { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

    }
}
