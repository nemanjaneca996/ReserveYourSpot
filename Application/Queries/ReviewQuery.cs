using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public class ReviewQuery : BaseQuery
    {
        public int? LocaleId { get; set; }
        public int? UserId { get; set; }
        public int? MinRating { get; set; }
    }
}
