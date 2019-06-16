using Application.DTO;
using Application.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.ReservationCommands
{
    public interface IGetReservationCommand : ICommand<int,ShowReservationDto>
    {
    }
}
