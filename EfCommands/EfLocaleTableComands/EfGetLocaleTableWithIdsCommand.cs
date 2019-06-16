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
    public class EfGetLocaleTableWithIdsCommand : EfBaseCommand, IGetLocaleTableWitIdsCommand
    {
        public EfGetLocaleTableWithIdsCommand(EfContext context) : base(context)
        {

        }
        public LocaleTableDto Execute(int request)
        {
            var localeTable = Context.LocaleTables.Find(request);

            if (localeTable == null)
                throw new NotFoundException("Locale Table");

            return new LocaleTableDto
            {
                Id = localeTable.Id,
                LocaleId = localeTable.LocaleId,
                Name = localeTable.Name,
                NumberOfSeats = localeTable.NumberOfSeats
            };
        }
    }
}
