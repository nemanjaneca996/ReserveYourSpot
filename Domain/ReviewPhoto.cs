using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ReviewPhoto : BaseEntity
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public int ReviewId { get; set; }
        public Review Review { get; set; }
    }
}
