using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class ShowLocaleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string EmailInfo { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string GoogleLocation { get; set; }
        public string LocaleTypeName { get; set; }
        public string CityName { get; set; }
        public string Description { get; set; }
        public IEnumerable<ShowLocalePhotoDto> Photos { get; set; }
        public IEnumerable<ShowLocaleMenuDto> Menus { get; set; }
    }
}
