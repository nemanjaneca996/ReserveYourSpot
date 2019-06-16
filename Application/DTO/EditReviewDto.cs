using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class EditReviewDto
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public int Rating { get; set; }
    }
}
