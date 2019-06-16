using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using API.Models;
using Application.Commands.LocaleMenuCommands;
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
    public class LocaleMenuController : ControllerBase
    {

        private readonly IAddLocaleMenuCommand _addMenu;
        private readonly IGetLocaleMenuCommand _getMenu;
        private readonly IGetLocaleMenusCommand _getMenus;
        private readonly IEditLocaleMenuCommand _editMenu;
        private readonly IDeleteLocaleMenuCommand _deleteMenu;
        private readonly LoggedUser _user;

        public LocaleMenuController(IAddLocaleMenuCommand addMenu, IGetLocaleMenuCommand getMenu, IGetLocaleMenusCommand getMenus, IEditLocaleMenuCommand editMenu, IDeleteLocaleMenuCommand deleteMenu, LoggedUser user)
        {
            _addMenu = addMenu;
            _getMenu = getMenu;
            _getMenus = getMenus;
            _editMenu = editMenu;
            _deleteMenu = deleteMenu;
            _user = user;
        }

        // GET: api/LocaleMenu
        [HttpGet]
        public ActionResult<PagedResponse<ShowLocaleMenuDto>> Get([FromQuery] LocaleFileQuery query)
        {
            return Ok(_getMenus.Execute(query));
        }

        // GET: api/LocaleMenu/5
        [HttpGet("{id}")]
        public ActionResult<ShowLocaleMenuDto> Get(int id)
        {
            try
            {
                return Ok(_getMenu.Execute(id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // POST: api/LocaleMenu
        [LoggedIn("Administrator")]
        [HttpPost]
        public IActionResult Post([FromForm] LocaleFileRequest request)
        {
            var ext = Path.GetExtension(request.File.FileName);

            if (ext != ".pdf")
            {
                return UnprocessableEntity("Document extension is not allowed");
            }
            var newFileName = Guid.NewGuid().ToString() + "_" + request.File.FileName;

            try
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "localeMenus", newFileName);

                request.File.CopyTo(new FileStream(filePath, FileMode.Create));

                var dto = new LocaleMenuDto
                {
                    Name = request.Name,
                    LocaleId = request.LocaleId,
                    Path = Path.Combine("uploads", "localePhotos", newFileName)

                };
                _addMenu.Execute(dto);

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

        // PUT: api/LocaleMenu/5
        [LoggedIn("Administrator")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EditFileName dto)
        {
            try
            {
                dto.Id = id;
                _editMenu.Execute(dto);
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
                _deleteMenu.Execute(id);
                return StatusCode(204);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
