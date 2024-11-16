using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandManager.Api.Resources.DTOs
{
    public class VenueDTO
    {
        [Required]
        public string ContactName { get; set; }
        [Required]
        public string ContactPhoneNumber { get; set; }
        [Required]
        public string ContactEmail { get; set; }
    }
}
