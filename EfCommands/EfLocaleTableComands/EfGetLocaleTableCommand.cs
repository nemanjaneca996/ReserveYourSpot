using Application.Commands.LocaleTableCommands;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfLocaleTableComands
{
    public class EfGetLocaleTableCommand : EfBaseCommand, IGetLocaleTableCommand
    {
        public EfGetLocaleTableCommand(EfContext context) : base(context)
        {

        }
        public ShowLocaleTableDto Execute(int request)
        {
            var localeTable = Context.LocaleTables
                .Include(lt => lt.Locale)
                .Include(lt => lt.Reservations)
                .Where(lt => lt.Id == request).FirstOrDefault(); ;

            if (localeTable == null)
                throw new NotFoundException("Locale Table");

            return new ShowLocaleTableDto
            {
                Id = localeTable.Id,
                LocaleName = localeTable.Locale.Name,
                Name = localeTable.Name,
                NumberOfSeats = localeTable.NumberOfSeats,
                IsReserved = localeTable.Reservations.Any(r => r.StartTime.DayOfYear == DateTime.Now.DayOfYear) ? true : false
            };
        }
    }
}
