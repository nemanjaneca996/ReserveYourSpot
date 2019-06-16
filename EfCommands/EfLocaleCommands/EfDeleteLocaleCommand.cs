using Application.Commands.LocaleCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.EfLocaleCommands
{
    public class EfDeleteLocaleCommand : EfBaseCommand, IDeleteLocaleCommand
    {
        public EfDeleteLocaleCommand(EfContext context) : base(context)
        {

        }
        public void Execute(int request)
        {
            var locale = Context.Locales.Find(request);

            if (locale == null)
                throw new Application.Exceptions.NotFoundException("Locale");

            Context.Locales.Remove(locale);
            Context.SaveChanges();

        }
    }
}
