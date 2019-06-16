using Application.Commands.LocaleCommands;
using Application.DTO;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfLocaleCommands
{
    public class EfAddLocaleCommand : EfBaseCommand, IAddLocaleCommand
    {
        public EfAddLocaleCommand(EfContext context):base(context)
        {

        }
        public void Execute(LocaleDto request)
        {
            if (Context.Locales.Any(l => l.Email == request.Email))
                throw new Application.Exceptions.EntityAlreadyExistsException("Email");

            if (Context.Locales.Any(l => l.Name == request.Name))
                throw new Application.Exceptions.EntityAlreadyExistsException("Name");

            if (!Context.Cities.Any(c => c.Id == request.CityId))
                throw new Application.Exceptions.NotFoundException("City");

            if (!Context.LocaleTypes.Any(c => c.Id == request.LocaleTypeId))
                throw new Application.Exceptions.NotFoundException("Locale Type");

            Context.Locales.Add(new Domain.Locale {
                Description = request.Description,
                Name = request.Name,
                Address = request.Address,
                CityId = request.CityId,
                Email = request.Email,
                EmailInfo = request.EmailInfo,
                Facebook =request.Facebook,
                GoogleLocation = request.GoogleLocation,
                Instagram = request.Instagram,
                LocaleTypeId = request.LocaleTypeId,
                Mobile = request.Mobile,
                Password = request.Password,
                Phone = request.Phone
            });
            Context.SaveChanges();
        }
    }
}
