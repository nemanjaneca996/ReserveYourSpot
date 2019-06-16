using Application.DTO;
using Application.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.LocaleTypeCommands
{
    public interface IGetLocaleTypeCommand : ICommand<int,ShowLocaleTypeDto>
    {
    }
}
