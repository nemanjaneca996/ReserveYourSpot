using Application.Commands.LocaleTypeCommands;
using Application.DTO;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.EfLocaleTypeCommands
{
    public class EfGetLocaleTypeCommand : EfBaseCommand, IGetLocaleTypeCommand
    {
        public EfGetLocaleTypeCommand(EfContext context) : base(context)
        {

        }
        public ShowLocaleTypeDto Execute(int request)
        {
            var localeType = Context.LocaleTypes.Find(request);

            if (localeType == null)
                throw new Application.Exceptions.NotFoundException("Locale Type");

            return new ShowLocaleTypeDto
            {
                Id = localeType.Id,
                Name = localeType.Name
            };
        }
    }
}
