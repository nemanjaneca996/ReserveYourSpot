using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class User : BaseUser
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
