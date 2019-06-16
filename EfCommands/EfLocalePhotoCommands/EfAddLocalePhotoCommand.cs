using Application.Commands.LocalePhotoCommands;
using Application.DTO;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfLocalePhotoCommands
{
    public class EfAddLocalePhotoCommand : EfBaseCommand, IAddLocalePhotoCommand
    {
        public EfAddLocalePhotoCommand(EfContext context) : base(context)
        {

        }
        public void Execute(LocalePhotoDto request)
        {
            if (!Context.Locales.Any(l => l.Id == request.LocaleId))
                throw new Application.Exceptions.NotFoundException("Locale");

            Context.LocalePhotos.Add(new Domain.LocalePhoto
            {
                LocaleId = request.LocaleId,
                Name = request.Name,
                Path = request.Path
            });

            Context.SaveChanges();
        }
    }
}
