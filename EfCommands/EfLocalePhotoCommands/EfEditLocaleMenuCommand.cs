using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.LocalePhotoCommands;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;

namespace EfCommands.EfLocalePhotoCommands
{
    public class EfEditLocalePhotoCommand : EfBaseCommand, IEditLocalePhotoCommand
    {
        public EfEditLocalePhotoCommand(EfContext context) : base(context)
        {
        }

        public void Execute(EditFileName request)
        {
            var tmp = Context.LocalePhotos.Find(request.Id);

            if (tmp == null)
                throw new NotFoundException("Locale photo");

            tmp.Name = request.Name;

            Context.SaveChanges();
        }
    }
}
