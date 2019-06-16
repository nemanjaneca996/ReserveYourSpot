using Application.Commands.LocaleMenuCommands;
using Application.DTO;
using Application.Intefaces;
using Application.Queries;
using Application.Responses;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfLocaleMenuCommands
{
    public class EfGetLocaleMenusCommand : EfBaseCommand, IGetLocaleMenusCommand
    {
        public EfGetLocaleMenusCommand(EfContext context) : base(context)
        {

        }

        public PagedResponse<ShowLocaleMenuDto> Execute(LocaleFileQuery request)
        {
            var query = Context.Menus.AsQueryable();

            if (request.LocaleId.HasValue)
                query = query.Where(lp => lp.LocaleId == request.LocaleId);

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<ShowLocaleMenuDto>
            {

                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = query.Select(m => new ShowLocaleMenuDto
                {
                    Name = m.Name,
                    LocaleName = m.Locale.Name,
                    Path = m.Path
                })

            };
        }

    }
}
