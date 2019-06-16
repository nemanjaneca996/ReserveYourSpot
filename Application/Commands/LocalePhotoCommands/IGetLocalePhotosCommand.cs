using Application.DTO;
using Application.Intefaces;
using Application.Queries;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.LocalePhotoCommands
{
    public interface IGetLocalePhotosCommand : ICommand<LocaleFileQuery, PagedResponse<ShowLocalePhotoDto>>
    {
    }
}
