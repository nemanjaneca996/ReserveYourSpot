using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class ReviewDto
    {
        [Required]
        public string Description { get; set; }
        public int Rating { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int LocaleId { get; set; }
    }
}
