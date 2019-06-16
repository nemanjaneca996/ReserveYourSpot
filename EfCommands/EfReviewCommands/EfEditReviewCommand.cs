using Application.Commands.ReviewCommands;
using Application.DTO;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.EfReviewCommands
{
    public class EfEditReviewCommand : EfBaseCommand, IEditReviewCommand
    {
        public EfEditReviewCommand(EfContext context) : base(context)
        {

        }
        public void Execute(EditReviewDto request)
        {
            var review = Context.Reviews.Find(request.Id);

            review.Description = request.Description;
            review.Rating = request.Rating;

            Context.SaveChanges();
        }
    }
}
