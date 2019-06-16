using Application.Commands.LocaleTypeCommands;
using Application.DTO;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfLocaleTypeCommands
{
    public class EfAddLocaleTypeCommand : EfBaseCommand, IAddLocaleTypeCommand
    {
        public EfAddLocaleTypeCommand(EfContext context):base(context)
        {

        }
        public void Execute(LocaleTypeDto request)
        {
            if (Context.LocaleTypes.Any(lt => lt.Name == request.Name))
                throw new Application.Exceptions.EntityAlreadyExistsException("Locale Type");

            Context.LocaleTypes.Add(new Domain.LocaleType
            {
                Name = request.Name
            });
            Context.SaveChanges();
        }
    }
}
