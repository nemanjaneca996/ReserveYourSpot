using Application.Commands.LocaleCommands;
using Application.DTO;
using Application.Queries;
using Application.Responses;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfLocaleCommands
{
    public class EfGetLocalesCommand : EfBaseCommand, IGetLocalesCommand
    {
        public EfGetLocalesCommand(EfContext context) : base(context)
        {

        }
        public PagedResponse<ShowLocaleDto> Execute(LocaleQuery request)
        {
            var query = Context.Locales.AsQueryable();

            if (request.CityId.HasValue)
                query = query.Where(l => l.CityId == request.CityId);

            if (request.LocaleTypeId.HasValue)
                query = query.Where(l => l.LocaleTypeId == request.LocaleTypeId);

            if (request.Name != null)
                query = query.Where(l => l.Name.ToLower().Contains(request.Name.ToLower()));

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<ShowLocaleDto>
            {

                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = query.Select(l => new ShowLocaleDto
                {
                    Id = l.Id,
                    Name = l.Name,
                    Address = l.Address,
                    Description = l.Description,
                    EmailInfo = l.EmailInfo,
                    Facebook = l.Facebook,
                    GoogleLocation =l.GoogleLocation,
                    Instagram = l.Instagram,
                    Menus = l.Menus.Select(m => new ShowLocaleMenuDto
                    {
                        LocaleName = l.Name,
                        Name =m.Name,
                         Path =m.Path
                    }),
                    Mobile = l.Mobile,
                    Phone = l.Phone,
                    Photos = l.LocalePhotos.Select(lp => new ShowLocalePhotoDto
                    {
                        LocaleName = l.Name,
                        Name = lp.Name,
                        Path = lp.Path
                    }),
                    CityName = l.City.Name,
                    LocaleTypeName = l.LocaleType.Name

                })

            };
        }
    }
}
