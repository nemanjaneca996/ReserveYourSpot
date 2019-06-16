using Application.Commands.LocaleCommands;
using Application.DTO;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.EfLocaleCommands
{
    public class EfGetLocaleWithIdsCommand : EfBaseCommand, IGetLocaleWithIdsCommand
    {
        public EfGetLocaleWithIdsCommand(EfContext context) : base(context)
        {

        }
        public LocaleDto Execute(int request)
        {
            var locale = Context.Locales.Find(request);

            if (locale == null)
                throw new Application.Exceptions.NotFoundException("Locale");

            return new LocaleDto
            {
                Id = locale.Id,
                Name = locale.Name,
                Address = locale.Address,
                Description = locale.Description,
                EmailInfo = locale.EmailInfo,
                Facebook = locale.Facebook,
                GoogleLocation = locale.GoogleLocation,
                Instagram = locale.Instagram,
                Mobile = locale.Mobile,
                Phone = locale.Phone,
                CityId = locale.CityId,
                Email = locale.Email,
                LocaleTypeId = locale.LocaleTypeId

            };
        }
    }
}
