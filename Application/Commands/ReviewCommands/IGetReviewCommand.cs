using Application.DTO;
using Application.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.ReviewCommands
{
    public interface IGetReviewCommand : ICommand<int,ShowReviewDto>
    {
    }
}
