using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class LocaleDto
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [StringLength(45,MinimumLength =5,ErrorMessage = "Name should be minimum 5 and maximum 45")]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string EmailInfo { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string GoogleLocation { get; set; }
        [Required]
        public int LocaleTypeId { get; set; }
        [Required]
        public int CityId { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
