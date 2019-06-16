using Application.Commands.ReservationCommands;
using Application.DTO;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfReservationCommands
{
    public class EfGetReservationCommand : EfBaseCommand, IGetReservationCommand
    {
        public EfGetReservationCommand(EfContext context) : base(context)
        {

        }
        public ShowReservationDto Execute(int request)
        {
            var reservation = Context.Reservations
                .Include(r => r.User)
                .Include(r => r.LocaleTable)
                .ThenInclude(lt => lt.Locale)
                .Where(r => r.Id == request).FirstOrDefault();

            if (reservation == null)
                throw new Application.Exceptions.NotFoundException("Reservation");


            return new ShowReservationDto
            {
                LocaleName = reservation.LocaleTable.Locale.Name,
                LocaleTableName =reservation.LocaleTable.Name,
                Peoples = reservation.Peoples,
                StartTime = reservation.StartTime,
                Username = reservation.User.Username
            };
        }
    }
}
