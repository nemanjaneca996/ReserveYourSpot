using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class LocaleTypeDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Name should be minimum 4 and maximum 15")]
        public string Name { get; set; }
    }
}
