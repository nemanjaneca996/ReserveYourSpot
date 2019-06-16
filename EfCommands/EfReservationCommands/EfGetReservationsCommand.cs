using Application.Commands.ReservationCommands;
using Application.DTO;
using Application.Queries;
using Application.Responses;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfReservationCommands
{
    public class EfGetReservationsCommand : EfBaseCommand, IGetReservationsCommand
    {
        public EfGetReservationsCommand(EfContext context) : base(context)
        {

        }
        public PagedResponse<ShowReservationDto> Execute(ReservationQuery request)
        {
            var query = Context.Reservations.AsQueryable();

            if (request.LocaleId.HasValue)
                query = query.Where(r => r.LocaleTable.LocaleId == request.LocaleId);

            if (request.LocaleTableId.HasValue)
                query = query.Where(r => r.LocaleTableId == request.LocaleTableId);

            if (request.Peoples.HasValue)
                query = query.Where(r => r.Peoples == request.Peoples);

            if(request.UserId.HasValue)
                query = query.Where(r => r.UserId == request.UserId);

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<ShowReservationDto>
            {
                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = query.Select(r => new ShowReservationDto
                {
                    Peoples = r.Peoples,
                    LocaleName = r.LocaleTable.Locale.Name,
                    LocaleTableName = r.LocaleTable.Name,
                    StartTime = r.StartTime,
                    Username = r.User.Username
                })
            };


        }
    }
}
