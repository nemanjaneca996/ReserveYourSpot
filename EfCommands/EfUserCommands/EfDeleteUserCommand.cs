using Application.Commands.UserCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.EfUserCommands
{
    public class EfDeleteUserCommand : EfBaseCommand, IDeleteUserCommand
    {
        public EfDeleteUserCommand(EfContext context):base(context)
        {
                
        }
        public void Execute(int request)
        {
            var user = Context.Users.Find(request);

            if (user == null)
                throw new Application.Exceptions.NotFoundException("User");

            Context.Users.Remove(user);
            Context.SaveChanges();
        }
    }
}
