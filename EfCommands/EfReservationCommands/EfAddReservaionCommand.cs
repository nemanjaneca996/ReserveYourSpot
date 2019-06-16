using Application.Commands.ReservationCommands;
using Application.DTO;
using Application.Exceptions;
using Application.Intefaces;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfReservationCommands
{
    public class EfAddReservaionCommand : EfBaseCommand, IAddReservationCommand
    {

        private readonly IEmailSender _emailSender;

        public EfAddReservaionCommand(EfContext context ,IEmailSender emailSender) : base(context)
        {
            _emailSender = emailSender;
        }
        public void Execute(ReservationDto request)
        {
            if (!Context.Users.Any(u => u.Id == request.UserId))
                throw new NotFoundException("User");

            if(!Context.LocaleTables.Any(lt => lt.Id == request.LocaleTableId))
                throw new NotFoundException("Locale Table");

            if (Context.LocaleTables.Find(request.LocaleTableId).NumberOfSeats < request.Peoples)
                throw new ReservationException("Impossible reservation for selected table");

            if (Context.Reservations.Where(r => r.LocaleTableId == request.LocaleTableId).Any(x=> x.StartTime.DayOfYear == request.StartTime.DayOfYear && x.StartTime.TimeOfDay <= request.StartTime.TimeOfDay))
                throw new ReservationException("Impossible to reserve alredy reserved table");

            Context.Reservations.Add(new Domain.Reservation
            {
                Peoples = request.Peoples,
                LocaleTableId = request.LocaleTableId,
                StartTime = request.StartTime,
                UserId = request.UserId
            });
            Context.SaveChanges();

            _emailSender.Subject = "Uspesna rezervacija";
            _emailSender.Body = "Uspesno ste rezervisali "+Context.LocaleTables.Find(request.LocaleTableId).Name;
            _emailSender.ToEmail = Context.Users.Find(request.UserId).Email;
            _emailSender.Send();
        }
    }
}
