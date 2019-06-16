using Application.Commands.LocaleMenuCommands;
using Application.DTO;
using Application.Intefaces;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfLocaleMenuCommands
{
    public class EfGetLocaleMenuCommand : EfBaseCommand, IGetLocaleMenuCommand
    {
        public EfGetLocaleMenuCommand(EfContext context) : base(context)
        {

        }

        ShowLocaleMenuDto ICommand<int, ShowLocaleMenuDto>.Execute(int request)
        {
            var menu = Context.Menus
                .Include(m => m.Locale)
                .Where(m => m.Id == request).FirstOrDefault();

            if (menu == null)
                throw new Application.Exceptions.NotFoundException("Menu");


            return new ShowLocaleMenuDto
            {
                LocaleName = menu.Locale.Name,
                Name = menu.Name,
                Path = menu.Path
            };
        }
    }
}
