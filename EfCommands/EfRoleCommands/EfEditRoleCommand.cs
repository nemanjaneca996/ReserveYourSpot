using Application.Commands.RoleCommands;
using Application.DTO;
using Application.Queries;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfRoleCommands
{
    public class EfEditRoleCommand : EfBaseCommand ,IEditRoleCommand
    {
        public EfEditRoleCommand(EfContext context):base(context)
        {

        }
        public void Execute(RoleDto request)
        {
            var role = Context.Roles.Find(request.Id);

            if (role == null)
                throw new Application.Exceptions.NotFoundException("Role");

            if (request.Name != role.Name && Context.Roles.Any(r => r.Name == request.Name))
                throw new Application.Exceptions.EntityAlreadyExistsException("Role");

            role.Name = request.Name;

            Context.SaveChanges();

        }
    }
}
