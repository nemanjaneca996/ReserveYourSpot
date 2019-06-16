using Application.Intefaces;
using Application.Queries;
using Application.Responses;
using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.UserCommands
{
    public interface IGetUsersCommand : ICommand<UserQuery, PagedResponse<ShowUserDto>>
    {
    }
}
