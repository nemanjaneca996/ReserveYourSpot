using Application.Commands.LocaleTableCommands;
using Application.DTO;
using Application.Queries;
using Application.Responses;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfLocaleTableComands
{
    public class EfGetLocaleTablesCommand : EfBaseCommand, IGetLocaleTablesCommand
    {
        public EfGetLocaleTablesCommand(EfContext context) : base(context)
        {

        }
        public PagedResponse<ShowLocaleTableDto> Execute(LocaleTableQuery request)
        {
            var query = Context.LocaleTables
                                .Include(lt => lt.Reservations)
                                .AsQueryable();

            if (request.LocaleId.HasValue)
                query = query.Where(lt => lt.LocaleId == request.LocaleId);

            if (request.MinNumberOfSeats.HasValue)
                query = query.Where(lt => lt.NumberOfSeats >= request.MinNumberOfSeats);

            if (request.Name != null)
                query = query.Where(lt => lt.Name.ToLower().Contains(request.Name.ToLower()));

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

           
            if (request.Reservation != null)
                return new PagedResponse<ShowLocaleTableDto>
                {
                    CurrentPage = request.PageNumber,
                    PagesCount = pagesCount,
                    TotalCount = totalCount,
                    Data = query.Select(lt => new ShowLocaleTableDto
                    {
                        Id = lt.Id,
                        Name = lt.Name,
                        NumberOfSeats = lt.NumberOfSeats,
                        LocaleName = lt.Locale.Name,
                        IsReserved = lt.Reservations.Any(r => r.StartTime.DayOfYear == request.Reservation.Value.DayOfYear) ? true : false
                    })
                };
            else
                return new PagedResponse<ShowLocaleTableDto>
                {
                    CurrentPage = request.PageNumber,
                    PagesCount = pagesCount,
                    TotalCount = totalCount,
                    Data = query.Select(lt => new ShowLocaleTableDto
                    {
                        Id = lt.Id,
                        Name = lt.Name,
                        NumberOfSeats = lt.NumberOfSeats,
                        LocaleName = lt.Locale.Name,
                        IsReserved = lt.Reservations.Any(r => r.StartTime.DayOfYear == DateTime.Now.DayOfYear) ? true : false
                    })
                };
        }
    }
}
