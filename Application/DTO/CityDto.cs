using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class CityDto 
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50,MinimumLength = 4, ErrorMessage = "Name should be minimum 4 and maximum 50")]
        public string Name { get; set; }
    }
}
