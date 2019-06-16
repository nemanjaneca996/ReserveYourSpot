using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Review : BaseEntity
    {
        public int Rating { get; set; }
        public string Description { get; set; }
        public ICollection<ReviewPhoto> ReviewPhotos { get; set; }
        public int UserId { get; set; }
        public int LocaleId { get; set; }
        public User User { get; set; }
        public Locale Locale { get; set; }
    }
}
