using Application.Commands.CityCommands;
using Application.DTO;
using Application.Intefaces;
using Application.Queries;
using Application.Responses;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfCityCommands
{
    public class EfGetCitiesCommand : EfBaseCommand,IGetCitiesCommand
    {
        public EfGetCitiesCommand(EfContext context):base(context)
        {
        }
        public PagedResponse<ShowCityDto> Execute(CityQuery request)
        {
            var query = Context.Cities.AsQueryable();

            if (request != null && request.Name != null)
                query = query.Where(r => r.Name.ToLower().Contains(request.Name.ToLower()));

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<ShowCityDto>
            {
                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = query.Select(c => new ShowCityDto
                {
                    Id = c.Id,
                    Name = c.Name
                })
            };
        }

    }
}
