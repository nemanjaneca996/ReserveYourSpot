using Application.DTO;
using Application.Intefaces;
using Application.Queries;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.CityCommands
{
    public interface IGetCitiesCommand : ICommand<CityQuery,PagedResponse<ShowCityDto>>
    {
    }
}
