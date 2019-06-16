using Application.Commands.CityCommands;
using Application.DTO;
using Application.Queries;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfCityCommands
{
    public class EfAddCityCommand : EfBaseCommand, IAddCityCommand
    {
        public EfAddCityCommand(EfContext context):base(context)
        {

        }
        public void Execute(CityDto request)
        {
            if (Context.Cities.Any(c => c.Name == request.Name))
                throw new Application.Exceptions.EntityAlreadyExistsException("City");

            Context.Cities.Add(new Domain.City
            {
                Name = request.Name
            });
            Context.SaveChanges();

        }
    }
}
