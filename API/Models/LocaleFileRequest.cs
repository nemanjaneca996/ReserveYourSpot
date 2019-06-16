using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class LocaleFileRequest
    {
        public string Name { get; set; }
        public IFormFile File { get; set; }
        public int LocaleId { get; set; }
    }
}
