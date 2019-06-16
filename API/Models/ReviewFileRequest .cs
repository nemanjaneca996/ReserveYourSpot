using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class ReviewFileRequest
    {
        public string Name { get; set; }
        public IFormFile File { get; set; }
        public int ReviewId { get; set; }
    }
}
