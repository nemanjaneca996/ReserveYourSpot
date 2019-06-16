using Application.DTO;
using Application.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.ReviewCommands
{
    public interface IAddReviewCommand : ICommand<ReviewDto>
    {
    }
}
