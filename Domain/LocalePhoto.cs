using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class LocalePhoto : BaseEntity
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public int LocaleId { get; set; }
        public Locale Locale { get; set; }
    }
}
