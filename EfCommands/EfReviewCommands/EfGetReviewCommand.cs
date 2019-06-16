using Application.Commands.ReviewCommands;
using Application.DTO;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfReviewCommands
{
    public class EfGetReviewCommand : EfBaseCommand, IGetReviewCommand
    {
        public EfGetReviewCommand(EfContext context) : base(context)
        {
            
        }
        public ShowReviewDto Execute(int request)
        {
            var review = Context.Reviews
                .Include(r => r.User)
                .Include(r => r.Locale)
                .Include(r => r.ReviewPhotos)
                .Where(r => r.Id == request).FirstOrDefault();

            if (review == null)
                throw new Application.Exceptions.NotFoundException("Review");

            return new ShowReviewDto
            {
                Description = review.Description,
                LocaleName = review.Locale.Name,
                Username =review.User.Username,
                Rating = review.Rating,
                Photos = review.ReviewPhotos.Select(p => new ShowReviewPhotoDto
                {
                    Name = p.Name,
                    Path = p.Path
                })
            };
        }
    }
}
