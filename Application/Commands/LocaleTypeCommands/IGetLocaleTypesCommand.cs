using Application.DTO;
using Application.Intefaces;
using Application.Queries;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.LocaleTypeCommands
{
    public interface IGetLocaleTypesCommand : ICommand<LocaleTypeQuery,PagedResponse<ShowLocaleTypeDto>>
    {
    }
}
