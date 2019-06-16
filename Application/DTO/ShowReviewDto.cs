using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class ShowReviewDto
    {
        public string Description { get; set; }
        public string Username { get; set; }
        public string LocaleName { get; set; }
        public int Rating { get; set; }
        public IEnumerable<ShowReviewPhotoDto> Photos { get; set; }
    }
}
