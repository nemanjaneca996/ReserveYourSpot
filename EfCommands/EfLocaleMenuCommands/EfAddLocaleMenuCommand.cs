using Application.Commands.LocaleMenuCommands;
using Application.Commands.LocalePhotoCommands;
using Application.DTO;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfLocaleMenuCommands
{
    public class EfAddLocaleMenuCommand : EfBaseCommand, IAddLocaleMenuCommand
    {
        public EfAddLocaleMenuCommand(EfContext context) : base(context)
        {

        }
        
        public void Execute(LocaleMenuDto request)
        {
            if (!Context.Locales.Any(l => l.Id == request.LocaleId))
                throw new Application.Exceptions.NotFoundException("Locale");

            Context.Menus.Add(new Domain.Menu
            {
                LocaleId = request.LocaleId,
                Name = request.Name,
                Path = request.Path
            });

            Context.SaveChanges();
        }
    }
}
