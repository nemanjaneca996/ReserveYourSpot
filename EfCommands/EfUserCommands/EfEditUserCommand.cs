using Application.Commands.UserCommands;
using Application.DTO;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfUserCommands
{
    public class EfEditUserCommand : EfBaseCommand, IEditUserCommand
    {
        public EfEditUserCommand(EfContext context) : base(context)
        {

        }

        public void Execute(UserDto request)
        {
            var user = Context.Users.Find(request.Id);

            if (user == null)
                throw new Application.Exceptions.NotFoundException("User");

            if (request.Username != user.Username && Context.Users.Any(u => u.Username == request.Username))
                throw new Application.Exceptions.EntityAlreadyExistsException("User");

            if (request.Email != user.Email && Context.Users.Any(u => u.Email == request.Email))
                throw new Application.Exceptions.EntityAlreadyExistsException("User");

            if (request.Password != null)
                user.Password = request.Password;
           
            user.Username = request.Username;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Mobile = request.Mobile;
            user.RoleId = request.RoleId;

            Context.SaveChanges();
        }
    }
}
