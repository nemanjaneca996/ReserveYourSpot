using Application.Commands.ReviewCommands;
using Application.DTO;
using Application.Queries;
using Application.Responses;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfReviewCommands
{
    public class EfGetReviewsCommand : EfBaseCommand, IGetReviewsCommand
    {
        public EfGetReviewsCommand(EfContext context) : base(context)
        {

        }
        public PagedResponse<ShowReviewDto> Execute(ReviewQuery request)
        {
            var query = Context.Reviews.AsQueryable();

            if (request.LocaleId.HasValue)
                query = query.Where(r => r.LocaleId == request.LocaleId);

            if (request.UserId.HasValue)
                query = query.Where(r => r.UserId == request.UserId);

            if (request.MinRating.HasValue)
                query = query.Where(r => r.Rating > request.MinRating);

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            return new PagedResponse<ShowReviewDto>
            {
                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = query.Select(r => new ShowReviewDto
                {
                    Rating = r.Rating,
                    Description = r.Description,
                    LocaleName = r.Locale.Name,
                    Username = r.User.Username,
                    Photos = r.ReviewPhotos.Select(p => new ShowReviewPhotoDto
                    {
                        Name = p.Name,
                        Path = p.Path
                    })
                })
            };
        }
    }
}
