using Application.Commands.ReservationCommands;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfReservationCommands
{
    public class EfEditReservationCommand : EfBaseCommand, IEditReservationCommand
    {
        public EfEditReservationCommand(EfContext context) : base(context)
        {

        }
        public void Execute(ReservationDto request)
        {
            var reservation = Context.Reservations.Find(request.Id);

            if (reservation.StartTime.DayOfYear == DateTime.Now.DayOfYear && reservation.StartTime.TimeOfDay < DateTime.Now.TimeOfDay.Add(TimeSpan.FromHours(1)))
                throw new ReservationException("It's too late to change your reservation");

            if (!Context.LocaleTables.Any(lt => lt.Id == request.LocaleTableId))
                throw new NotFoundException("Locale Table");

            if (Context.LocaleTables.Find(request.LocaleTableId).NumberOfSeats < request.Peoples)
                throw new ReservationException("Impossible reservation for selected table");

            if (request.StartTime != reservation.StartTime 
                && Context.Reservations.Where(r => r.LocaleTableId == request.LocaleTableId && r.Id != request.Id).Any(x => x.StartTime.DayOfYear == request.StartTime.DayOfYear 
                && x.StartTime.TimeOfDay <= request.StartTime.TimeOfDay))
                throw new ReservationException("Impossible to reserve alredy reserved table");

            reservation.StartTime = request.StartTime;
            reservation.LocaleTableId = request.LocaleTableId;
            reservation.Peoples = request.Peoples;

            Context.SaveChanges();

        }
    }
}
