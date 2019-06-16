using Application.Commands.ReviewCommands;
using Application.DTO;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfReviewCommands
{
    public class EfAddReviewCommand : EfBaseCommand, IAddReviewCommand
    {
        public EfAddReviewCommand(EfContext context) : base(context)
        {

        }
        public void Execute(ReviewDto request)
        {
            if (!Context.Users.Any(r => r.Id == request.UserId))
                throw new Application.Exceptions.NotFoundException("User");

            if (!Context.Locales.Any(r => r.Id == request.LocaleId))
                throw new Application.Exceptions.NotFoundException("Locale");

            Context.Reviews.Add(new Domain.Review
            {
                LocaleId = request.LocaleId,
                Description = request.Description,
                UserId = request.UserId,
                Rating = request.Rating
            });

            Context.SaveChanges();

        }
    }
}
