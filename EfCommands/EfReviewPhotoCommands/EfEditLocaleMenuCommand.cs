using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.ReviewPhotoCommands;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;

namespace EfCommands.EfReviewPhotoCommands
{
    public class EfEditReviewPhotoCommand : EfBaseCommand, IEditReviewPhotoCommand
    {
        public EfEditReviewPhotoCommand(EfContext context) : base(context)
        {
        }

        public void Execute(EditFileName request)
        {
            var tmp = Context.ReviewPhotos.Find(request.Id);

            if (tmp == null)
                throw new NotFoundException("review photo");

            tmp.Name = request.Name;

            Context.SaveChanges();
        }
    }
}
