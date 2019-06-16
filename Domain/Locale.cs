using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Locale : BaseUser
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string EmailInfo { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Description { get; set; }
        public string GoogleLocation { get; set; }
        public ICollection<LocaleTable> LocaleTables { get; set; }
        public ICollection<LocalePhoto> LocalePhotos { get; set; }
        public ICollection<Menu> Menus { get; set; }
        public int LocaleTypeId { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public LocaleType LocaleType { get; set; }
    }
}
