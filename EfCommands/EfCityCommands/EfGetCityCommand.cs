using Application.Commands.CityCommands;
using Application.DTO;
using Application.Queries;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.EfCityCommands
{
    public class EfGetCityCommand : EfBaseCommand, IGetCityCommand
    {
        public EfGetCityCommand(EfContext context):base(context)
        {

        }
        public ShowCityDto Execute(int request)
        {
            var city = Context.Cities.Find(request);

            if (city == null)
                throw new Application.Exceptions.NotFoundException("City");

            return new ShowCityDto
            {
                Id = city.Id,
                Name = city.Name
            };
        }
    }
}
