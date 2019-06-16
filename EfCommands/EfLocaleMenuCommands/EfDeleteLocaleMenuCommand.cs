using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.LocaleMenuCommands;
using Application.Exceptions;
using EfDataAccess;

namespace EfCommands.EfLocaleMenuCommands
{
    public class EfDeleteLocaleMenuCommand : EfBaseCommand, IDeleteLocaleMenuCommand
    {
        public EfDeleteLocaleMenuCommand(EfContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var tmp = Context.Menus.Find(request);

            if (tmp == null)
                throw new NotFoundException("Menu");

            Context.Menus.Remove(tmp);
            Context.SaveChanges();
        }
    }
}
