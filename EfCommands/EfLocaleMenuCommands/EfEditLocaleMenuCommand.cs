using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.LocaleMenuCommands;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;

namespace EfCommands.EfLocaleMenuCommands
{
    public class EfEditLocaleMenuCommand : EfBaseCommand, IEditLocaleMenuCommand
    {
        public EfEditLocaleMenuCommand(EfContext context) : base(context)
        {
        }

        public void Execute(EditFileName request)
        {
            var tmp = Context.Menus.Find(request.Id);

            if (tmp == null)
                throw new NotFoundException("Menu");

            tmp.Name = request.Name;

            Context.SaveChanges();
        }
    }
}
