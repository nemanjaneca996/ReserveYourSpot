using Application.Commands.RoleCommands;
using Application.DTO;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.EfRoleCommands
{
    public class EfGetRoleCommand : EfBaseCommand, IGetRoleCommand
    {
        public EfGetRoleCommand(EfContext context):base(context)
        {
        }

        public ShowRoleDto Execute(int request)
        {
            var role = Context.Roles.Find(request);

            if (role == null)
                throw new Application.Exceptions.NotFoundException("Role");

            return new ShowRoleDto
            {
                Name = role.Name
            };
        }
    }
}
