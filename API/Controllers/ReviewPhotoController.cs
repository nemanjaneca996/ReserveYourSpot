using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Application.Commands.ReviewPhotoCommands;
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
    public class ReviewPhotoController : ControllerBase
    {
        private readonly IAddReviewPhotoCommand _addPhotoCommand;
        private readonly IGetReviewPhotosCommand _getPhotosCommand;
        private readonly IGetReviewPhotoCommand _getPhotoCommand;
        private readonly IDeleteReviewPhotoCommand _deletePhoto;
        private readonly IEditReviewPhotoCommand _editPhoto;

        public ReviewPhotoController(IAddReviewPhotoCommand addPhotoCommand, IGetReviewPhotosCommand getPhotosCommand, IGetReviewPhotoCommand getPhotoCommand, IDeleteReviewPhotoCommand deletePhoto, IEditReviewPhotoCommand editPhoto)
        {
            _addPhotoCommand = addPhotoCommand;
            _getPhotosCommand = getPhotosCommand;
            _getPhotoCommand = getPhotoCommand;
            _deletePhoto = deletePhoto;
            _editPhoto = editPhoto;
        }

        // GET: api/ReviewPhoto
        [HttpGet]
        public ActionResult<PagedResponse<ShowReviewPhotoDto>> Get([FromQuery] ReviewPhotoQuery query)
        {
            return Ok(_getPhotosCommand.Execute(query));
        }

        // GET: api/ReviewPhoto/5
        [HttpGet("{id}")]
        public ActionResult<ShowReviewPhotoDto> Get(int id)
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

        // POST: api/ReviewPhoto
        [HttpPost]
        public IActionResult Post([FromForm] ReviewFileRequest request)
        {
            var ext = Path.GetExtension(request.File.FileName);

            if (!UploadFile.AllowedExtensions.Contains(ext))
            {
                return UnprocessableEntity("Image extension is not allowed");
            }
            var newFileName = Guid.NewGuid().ToString() + "_" + request.File.FileName;

            try
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "reviewPhotos", newFileName);

                request.File.CopyTo(new FileStream(filePath, FileMode.Create));

                var dto = new ReviewPhotoDto
                {
                    Name = request.Name,
                    ReviewId = request.ReviewId,
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

        // PUT: api/ReviewPhoto/5
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
