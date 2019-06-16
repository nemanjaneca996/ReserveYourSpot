using Application.DTO;
using Application.Helpers;
using Application.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.UserCommands
{
    public interface ILoginUserCommand : ICommand<LoginUser, LoggedUser>
    {
    }
}
