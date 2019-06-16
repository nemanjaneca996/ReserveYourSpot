using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using API.Models;
using Application.Commands.LocalePhotoCommands;
using Application.DTO;
using Application.Exceptions;
using Application.Helpers;
using Application.Queries;
using Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalePhotoController : ControllerBase
    {

        private readonly IAddLocalePhotoCommand _addPhotoCommand;
        private readonly IGetLocalePhotosCommand _getPhotosCommand;
        private readonly IGetLocalePhotoCommand _getPhotoCommand;
        private readonly IDeleteLocalePhotoCommand _deletePhoto;
        private readonly IEditLocalePhotoCommand _editPhoto;
        private readonly LoggedUser _user;

        public LocalePhotoController(IAddLocalePhotoCommand addPhotoCommand, IGetLocalePhotosCommand getPhotosCommand, IGetLocalePhotoCommand getPhotoCommand, IDeleteLocalePhotoCommand deletePhoto, IEditLocalePhotoCommand editPhoto, LoggedUser user)
        {
            _addPhotoCommand = addPhotoCommand;
            _getPhotosCommand = getPhotosCommand;
            _getPhotoCommand = getPhotoCommand;
            _deletePhoto = deletePhoto;
            _editPhoto = editPhoto;
            _user = user;
        }

        // GET: api/LocalePhoto
        [HttpGet]
        public ActionResult<PagedResponse<ShowLocalePhotoDto>> Get([FromQuery] LocaleFileQuery query)
        {
            return Ok(_getPhotosCommand.Execute(query));
        }

        // GET: api/LocalePhoto/5
        [HttpGet("{id}")]
        public ActionResult<ShowLocalePhotoDto> Get(int id)
        {
            try
            {
                return Ok(_getPhotoCommand.Execute(id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // POST: api/LocalePhoto
        [LoggedIn("Administrator")]
        [HttpPost]
        public IActionResult Post([FromForm] LocaleFileRequest request)
        {
            var ext = Path.GetExtension(request.File.FileName);

            if (!UploadFile.AllowedExtensions.Contains(ext))
            {
                return UnprocessableEntity("Image extension is not allowed");
            }
            var newFileName = Guid.NewGuid().ToString() + "_" + request.File.FileName;

            try
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "localePhotos", newFileName);

                request.File.CopyTo(new FileStream(filePath, FileMode.Create));

                var dto = new LocalePhotoDto
                {
                    Name = request.Name,
                    LocaleId =request.LocaleId,
                    Path = Path.Combine("uploads", "localePhotos", newFileName)

                };
                _addPhotoCommand.Execute(dto);

                return StatusCode(201);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // PUT: api/LocalePhoto/5
        [LoggedIn("Administrator")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EditFileName dto)
        {
            try
            {
                dto.Id = id;
                _editPhoto.Execute(dto);
                return StatusCode(204);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [LoggedIn("Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deletePhoto.Execute(id);
                return StatusCode(204);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
