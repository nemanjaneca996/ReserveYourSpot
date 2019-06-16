using Application.DTO;
using Application.Intefaces;
using Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.CityCommands
{
    public interface IGetCityCommand : ICommand<int, ShowCityDto>
    {
    }
}
