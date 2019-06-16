using Application.Commands.ReviewCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.EfReviewCommands
{
    public class EfDeleteReviewCommand : EfBaseCommand, IDeleteReviewCommand
    {
        public EfDeleteReviewCommand(EfContext context) : base(context)
        {

        }
        public void Execute(int request)
        {
            var review = Context.Reviews.Find(request);

            if (review == null)
                throw new Application.Exceptions.NotFoundException("Review");

            Context.Reviews.Remove(review);
            Context.SaveChanges();
        }
    }
}
