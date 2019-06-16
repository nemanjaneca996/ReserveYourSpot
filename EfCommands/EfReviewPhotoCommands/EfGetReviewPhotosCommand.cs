using Application.Commands.ReviewPhotoCommands;
using Application.DTO;
using Application.Queries;
using Application.Responses;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfReviewPhotoCommands
{
    public class EfGetReviewPhotosCommand : EfBaseCommand, IGetReviewPhotosCommand
    {
        public EfGetReviewPhotosCommand(EfContext context) : base(context)
        {

        }
        public PagedResponse<ShowReviewPhotoDto> Execute(ReviewPhotoQuery request)
        {
            var query = Context.ReviewPhotos.AsQueryable();

            if (request.ReviewId.HasValue)
                query = query.Where(rp => rp.ReviewId == request.ReviewId);

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<ShowReviewPhotoDto>
            {

                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = query.Select(lp => new ShowReviewPhotoDto
                {
                    Name = lp.Name,
                    Path = lp.Path
                })

            };
        }
    }
}
