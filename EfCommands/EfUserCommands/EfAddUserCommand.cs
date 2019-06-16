using Application.Commands.UserCommands;
using Application.DTO;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace EfCommands.EfUserCommands
{
    public class EfAddUserCommand : EfBaseCommand, IAddUserCommand
    {

        public EfAddUserCommand(EfContext context):base(context)
        {
        }
        public void Execute(UserDto request)
        {
            if (Context.Users.Any(u => u.Username == request.Username))
                throw new Application.Exceptions.EntityAlreadyExistsException("User");

            if (Context.Users.Any(u => u.Email == request.Email))
                throw new Application.Exceptions.EntityAlreadyExistsException("User");

            Context.Users.Add(new Domain.User
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Mobile = request.Mobile,
                RoleId = request.RoleId,
                Password = request.Password,
                Username = request.Username
        });
            Context.SaveChanges();
        }
    }
}
