using Application.Commands.LocaleCommands;
using Application.Commands.LocaleTableCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.EfLocaleTableComands
{
    public class EfDeleteLocaleTableCommand : EfBaseCommand, IDeleteLocaleTableCommand
    {
        public EfDeleteLocaleTableCommand(EfContext context) : base(context)
        {

        }
        public void Execute(int request)
        {
            var localeTable = Context.LocaleTables.Find(request);

            if (localeTable == null)
                throw new Application.Exceptions.NotFoundException("Locale Tables");

            Context.LocaleTables.Remove(localeTable);
            Context.SaveChanges();
        }
    }
}
