using Application.Commands.UserCommands;
using Application.DTO;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfUserCommands
{
    public class EfGetUserCommand : EfBaseCommand,IGetUserCommand
    {
        public EfGetUserCommand(EfContext context) : base(context)
        {

        }
        public ShowUserDto Execute(int request)
        {
            var user = Context.Users
                .Include(u => u.Role)
                .Where(u => u.Id == request).FirstOrDefault();

            if (user == null)
                throw new Application.Exceptions.NotFoundException("User");

            var dto = new ShowUserDto
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Mobile = user.Mobile,
                RoleName = user.Role.Name,
                Username = user.Username,
            };
            return dto;
        }
    }
}
