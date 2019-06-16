using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public class LocaleQuery : BaseQuery
    {
        public int? LocaleTypeId { get; set; }
        public int? CityId { get; set; }
        public string Name { get; set; }
    }
}
