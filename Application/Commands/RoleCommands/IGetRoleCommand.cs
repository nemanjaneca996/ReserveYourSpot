using Application.DTO;
using Application.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.RoleCommands
{
    public interface IGetRoleCommand : ICommand<int, ShowRoleDto>
    {
    }
}
