using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Locale> Locales { get; set; }
    }
}
