using Application.Commands.LocalePhotoCommands;
using Application.DTO;
using Application.Queries;
using Application.Responses;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfLocalePhotoCommands
{
    public class EfGetLocalePhotosCommand : EfBaseCommand, IGetLocalePhotosCommand
    {
        public EfGetLocalePhotosCommand(EfContext context) : base(context)
        {

        }
        public PagedResponse<ShowLocalePhotoDto> Execute(LocaleFileQuery request)
        {
            var query = Context.LocalePhotos.AsQueryable();

            if (request.LocaleId != null)
                query = query.Where(lp => lp.LocaleId == request.LocaleId);

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<ShowLocalePhotoDto>
            {

                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = query.Select(lp => new ShowLocalePhotoDto
                {
                    Name = lp.Name,
                    LocaleName = lp.Locale.Name,
                    Path = lp.Path
                })
            
            };



        }
    }
}
