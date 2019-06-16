using Application.Commands.LocaleTypeCommands;
using Application.DTO;
using Application.Queries;
using Application.Responses;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfLocaleTypeCommands
{
    public class EfGetLocaleTypesCommand : EfBaseCommand, IGetLocaleTypesCommand
    {
        public EfGetLocaleTypesCommand(EfContext context):base(context)
        {

        }
        public PagedResponse<ShowLocaleTypeDto> Execute(LocaleTypeQuery request)
        {
            var localeType = Context.LocaleTypes.AsQueryable();

            if (request.Name != null)
                localeType = localeType.Where(lt => lt.Name.ToLower().Contains(request.Name.ToLower()));

            var totalCount = localeType.Count();

            localeType = localeType.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<ShowLocaleTypeDto>
            {
                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = localeType.Select(lt => new ShowLocaleTypeDto {
                    Id = lt.Id,
                    Name = lt.Name
                })
            };


        }
    }
}
