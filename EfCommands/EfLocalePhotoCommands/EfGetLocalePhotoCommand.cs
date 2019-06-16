using Application.Commands.LocalePhotoCommands;
using Application.DTO;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfLocalePhotoCommands
{
    public class EfGetLocalePhotoCommand : EfBaseCommand, IGetLocalePhotoCommand
    {
        public EfGetLocalePhotoCommand(EfContext context) : base(context)
        {

        }
        public ShowLocalePhotoDto Execute(int request)
        {
            var localePhoto = Context.LocalePhotos
                .Include(lp => lp.Locale)
                .Where(lp => lp.Id == request).FirstOrDefault();

            if (localePhoto == null)
                throw new Application.Exceptions.NotFoundException("Locale Photo");


            return new ShowLocalePhotoDto
            {
                LocaleName = localePhoto.Locale.Name,
                Name = localePhoto.Name,
                Path = localePhoto.Path
            };
        }
    }
}
