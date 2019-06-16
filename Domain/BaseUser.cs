using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class BaseUser : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
