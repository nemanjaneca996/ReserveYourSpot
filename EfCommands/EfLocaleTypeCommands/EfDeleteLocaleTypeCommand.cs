using Application.Commands.LocaleTypeCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.EfLocaleTypeCommands
{
    public class EfDeleteLocaleTypeCommand : EfBaseCommand, IDeleteLocaleTypeCommand
    {
        public EfDeleteLocaleTypeCommand(EfContext context) : base(context)
        {

        }
        public void Execute(int request)
        {
            var localeType = Context.LocaleTypes.Find(request);

            if (localeType == null)
                throw new Application.Exceptions.NotFoundException("Locale Type");

            Context.LocaleTypes.Remove(localeType);
            Context.SaveChanges();
        }
    }
}
