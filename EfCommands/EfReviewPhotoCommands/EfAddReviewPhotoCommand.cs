using Application.Commands.ReviewPhotoCommands;
using Application.DTO;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.EfReviewPhotoCommands
{
    public class EfAddReviewPhotoCommand : EfBaseCommand, IAddReviewPhotoCommand
    {
        public EfAddReviewPhotoCommand(EfContext context) : base(context)
        {

        }
        public void Execute(ReviewPhotoDto request)
        {
            if (!Context.Reviews.Any(r => r.Id == request.ReviewId))
                throw new Application.Exceptions.NotFoundException("Review");

            Context.ReviewPhotos.Add(new Domain.ReviewPhoto
            {
                ReviewId = request.ReviewId,
                Name = request.Name,
                Path = request.Path
            });

            Context.SaveChanges();
        }
    }
}
