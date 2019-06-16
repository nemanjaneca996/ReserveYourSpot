using Application.Commands.LocaleCommands;
using Application.DTO;
using Application.Intefaces;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfLocaleCommands
{
    public class EfGetLocaleCommand : EfBaseCommand, IGetLocaleCommand
    {
        public EfGetLocaleCommand(EfContext context) : base(context)
        {
                
        }
        public ShowLocaleDto Execute(int request)
        {
            var locale = Context.Locales
                .Include(l => l.Menus)
                .Include(l => l.LocalePhotos)
                .Include(l => l.City)
                .Include(l => l.LocaleType)
                .Where(l => l.Id == request).FirstOrDefault();

            if (locale == null)
                throw new Application.Exceptions.NotFoundException("Locale");

            return new ShowLocaleDto
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
                Menus = locale.Menus.Select(m => new ShowLocaleMenuDto
                {
                    LocaleName = locale.Name,
                    Name = m.Name,
                    Path = m.Path
                }),
                Photos = locale.LocalePhotos.Select(lp => new ShowLocalePhotoDto
                {
                    LocaleName = locale.Name,
                    Name = lp.Name,
                    Path = lp.Path
                }),
                CityName = locale.City.Name,
                LocaleTypeName = locale.LocaleType.Name

            };
        }

    }
}
