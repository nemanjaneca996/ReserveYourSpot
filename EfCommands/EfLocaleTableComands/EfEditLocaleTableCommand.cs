using Application.Commands.LocaleCommands;
using Application.Commands.LocaleTableCommands;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfLocaleTableComands
{
    public class EfEditLocaleTableCommand : EfBaseCommand, IEditLocaleTableCommand
    {
        public EfEditLocaleTableCommand(EfContext context) : base(context)
        {

        }

        public void Execute(LocaleTableDto request)
        {
            var localeTable = Context.LocaleTables.Find(request.Id);

            if (localeTable.Name != request.Name && Context.LocaleTables.Where(lc => lc.LocaleId == request.LocaleId).Any(lc => lc.Name == request.Name))
                throw new EntityAlreadyExistsException("Name");

            if (!Context.Locales.Any(l => l.Id == request.LocaleId))
                throw new NotFoundException("Locale");

            localeTable.Name = request.Name;
            localeTable.NumberOfSeats = request.NumberOfSeats;
            localeTable.LocaleId = request.LocaleId;

            Context.SaveChanges();
            
        }
    }
}
