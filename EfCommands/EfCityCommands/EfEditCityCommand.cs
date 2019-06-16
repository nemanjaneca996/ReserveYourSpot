using Application.Commands.CityCommands;
using Application.DTO;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfCityCommands
{
    public class EfEditCityCommand : EfBaseCommand, IEditCityCommand
    {
        public EfEditCityCommand(EfContext context):base(context)
        {

        }
        public void Execute(CityDto request)
        {
            var city = Context.Cities.Find(request.Id);

            if (city == null)
                throw new Application.Exceptions.NotFoundException("City");

            if (request.Name != city.Name && Context.Cities.Any(c => c.Name == request.Name))
                throw new Application.Exceptions.EntityAlreadyExistsException("City");

            city.Name = request.Name;
            Context.SaveChanges();
        }
    }
}
