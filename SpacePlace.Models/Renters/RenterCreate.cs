using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePlace.Models
{
    public class RenterCreate
    {
        [Required]
        public string RenterID { get; set; }
    }
}