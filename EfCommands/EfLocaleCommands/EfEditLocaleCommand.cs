using Application.Commands.LocaleCommands;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfLocaleCommands
{
    public class EfEditLocaleCommand : EfBaseCommand, IEditLocaleCommand
    {
        public EfEditLocaleCommand(EfContext context) : base(context)
        {

        }
        public void Execute(LocaleDto request)
        {
            var locale = Context.Locales.Find(request.Id);

            if (locale == null)
                throw new NotFoundException("Locale");

            if (locale.Email != request.Email && Context.Locales.Any(l => l.Email == request.Email))
                throw new Application.Exceptions.EntityAlreadyExistsException("Email");

            if (locale.Name != request.Name && Context.Locales.Any(l => l.Name == request.Name))
                throw new Application.Exceptions.EntityAlreadyExistsException("Name");

            if (!Context.Cities.Any(c => c.Id == request.CityId))
                throw new Application.Exceptions.NotFoundException("City");

            if (!Context.LocaleTypes.Any(c => c.Id == request.LocaleTypeId))
                throw new Application.Exceptions.NotFoundException("Locale Type");

            if (request.Password != null)
                locale.Password = request.Password;

            locale.Name = request.Name;
            locale.Address = request.Address;
            locale.CityId = request.CityId;
            locale.Email = request.Email;
            locale.EmailInfo = request.EmailInfo;
            locale.Facebook = request.Facebook;
            locale.GoogleLocation = request.GoogleLocation;
            locale.Instagram = request.Instagram;
            locale.LocaleTypeId = request.LocaleTypeId;
            locale.Mobile = request.Mobile;
            locale.Phone = request.Phone;
            locale.Description = request.Description;

            Context.SaveChanges();

        }
    }
}
