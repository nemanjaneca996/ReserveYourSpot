using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.ReviewPhotoCommands;
using Application.Exceptions;
using EfDataAccess;

namespace EfCommands.EfReviewPhotoCommands
{
    public class EfDeleteReviewPhotoCommand : EfBaseCommand, IDeleteReviewPhotoCommand
    {
        public EfDeleteReviewPhotoCommand(EfContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var tmp = Context.ReviewPhotos.Find(request);

            if (tmp == null)
                throw new NotFoundException("review photo");

            Context.ReviewPhotos.Remove(tmp);
            Context.SaveChanges();
        }
    }
}
