using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.LocalePhotoCommands;
using Application.Exceptions;
using EfDataAccess;

namespace EfCommands.EfLocalePhotoCommands
{
    public class EfDeleteLocalePhotoCommand : EfBaseCommand, IDeleteLocalePhotoCommand
    {
        public EfDeleteLocalePhotoCommand(EfContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var tmp = Context.LocalePhotos.Find(request);

            if (tmp == null)
                throw new NotFoundException("Locale photo");

            Context.LocalePhotos.Remove(tmp);
            Context.SaveChanges();
        }
    }
}
