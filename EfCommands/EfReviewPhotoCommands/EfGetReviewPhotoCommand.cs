using Application.Commands.ReviewPhotoCommands;
using Application.DTO;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.EfReviewPhotoCommands
{
    public class EfGetReviewPhotoCommand : EfBaseCommand, IGetReviewPhotoCommand
    {
        public EfGetReviewPhotoCommand(EfContext context) : base(context)
        {

        }
        public ShowReviewPhotoDto Execute(int request)
        {
            var reviewPhoto = Context.ReviewPhotos.Find(request);

            if (reviewPhoto == null)
                throw new Application.Exceptions.NotFoundException("Review Photo");


            return new ShowReviewPhotoDto
            {
                Name = reviewPhoto.Name,
                Path = reviewPhoto.Path
            };
        }
    }
}
