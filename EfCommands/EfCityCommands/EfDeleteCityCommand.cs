using Application.Commands.CityCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.EfCityCommands
{
    public class EfDeleteCityCommand : EfBaseCommand, IDeleteCityCommand
    {
        public EfDeleteCityCommand(EfContext context):base(context)
        {

        }
        public void Execute(int request)
        {
            var city = Context.Cities.Find(request);

            if (city == null)
                throw new Application.Exceptions.NotFoundException("City");

            Context.Cities.Remove(city);
            Context.SaveChanges();
        }
    }
}
