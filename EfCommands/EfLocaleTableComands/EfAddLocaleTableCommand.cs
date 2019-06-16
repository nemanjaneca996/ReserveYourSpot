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
    public class EfAddLocaleTableCommand : EfBaseCommand, IAddLocaleTableCommand
    {
        public EfAddLocaleTableCommand(EfContext context):base(context)
        {

        }
        public void Execute(LocaleTableDto request)
        {
            if (Context.LocaleTables.Where(lc => lc.LocaleId == request.LocaleId).Any(lc => lc.Name == request.Name))
                throw new EntityAlreadyExistsException("Name");
            
            if (!Context.Locales.Any(l => l.Id == request.LocaleId))
                throw new NotFoundException("Locale");

            Context.LocaleTables.Add(new Domain.LocaleTable
            {
                LocaleId = request.LocaleId,
                Name = request.Name,
                NumberOfSeats = request.NumberOfSeats
            });

            Context.SaveChanges();
        }
    }
}
