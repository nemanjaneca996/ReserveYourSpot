using Application.Commands.ReservationCommands;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.EfReservationCommands
{
    public class EfDeleteReservationCommand : EfBaseCommand, IDeleteReservationCommand
    {
        public EfDeleteReservationCommand(EfContext context) : base(context)
        {

        }
        public void Execute(int request)
        {
            var reservation = Context.Reservations.Find(request);

            if (reservation == null)
                throw new Application.Exceptions.NotFoundException("Reservation");

            if(reservation.StartTime.DayOfYear == DateTime.Now.DayOfYear && reservation.StartTime.TimeOfDay < DateTime.Now.TimeOfDay.Add(TimeSpan.FromHours(1)) && reservation.StartTime.TimeOfDay > DateTime.Now.TimeOfDay)
                throw new ReservationException("It's too late to change your reservation");

            Context.Reservations.Remove(reservation);

            Context.SaveChanges();
        }
    }
}
