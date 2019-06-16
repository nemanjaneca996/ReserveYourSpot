using Application.Commands.LocaleTypeCommands;
using Application.DTO;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfLocaleTypeCommands
{
    public class EfEditLocaleTypeCommand : EfBaseCommand, IEditLocaleTypeCommand
    {
        public EfEditLocaleTypeCommand(EfContext context) : base(context)
        {

        }
        public void Execute(LocaleTypeDto request)
        {
            var localeType = Context.LocaleTypes.Find(request.Id);

            if (localeType == null)
                throw new Application.Exceptions.NotFoundException("Locale Type");

            if (localeType.Name != null && Context.LocaleTypes.Any(lt => lt.Name == request.Name))
                throw new Application.Exceptions.EntityAlreadyExistsException("Locale Type");

            localeType.Name = request.Name;

            Context.SaveChanges();
        }
    }
}
