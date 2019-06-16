using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using Application.Commands.LocaleCommands;
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
    public class LocaleController : ControllerBase
    {
        private readonly IAddLocaleCommand _addLocale;
        private readonly IDeleteLocaleCommand _deleteLocale;
        private readonly IEditLocaleCommand _editLocale;
        private readonly IGetLocalesCommand _getLocales;
        private readonly IGetLocaleCommand _getLocale;
        private readonly LoggedUser _user;

        public LocaleController(IAddLocaleCommand addLocale, IDeleteLocaleCommand deleteLocale, IEditLocaleCommand editLocale, IGetLocalesCommand getLocales, IGetLocaleCommand getLocale, LoggedUser user)
        {
            _addLocale = addLocale;
            _deleteLocale = deleteLocale;
            _editLocale = editLocale;
            _getLocales = getLocales;
            _getLocale = getLocale;
            _user = user;
        }


        // GET: api/Locale
        [HttpGet]
        public ActionResult<PagedResponse<ShowLocaleDto>> Get([FromQuery] LocaleQuery query)
        {
            return Ok(_getLocales.Execute(query));
        }

        // GET: api/Locale/5
        [HttpGet("{id}")]
        public ActionResult<ShowLocaleDto> Get(int id)
        {
            try
            {
                return Ok(_getLocale.Execute(id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // POST: api/Locale
        [LoggedIn("Administrator")]
        [HttpPost]
        public IActionResult Post([FromBody] LocaleDto dto)
        {
            try
            {
                _addLocale.Execute(dto);
                return StatusCode(201);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch(EntityAlreadyExistsException e)
            {
                return StatusCode(422, e.Message);
            }
        }

        // PUT: api/Locale/5
        [LoggedIn("Administrator")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LocaleDto dto)
        {
            try
            {
                dto.Id = id;
                _editLocale.Execute(dto);
                return StatusCode(204);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (EntityAlreadyExistsException e)
            {
                return StatusCode(422, e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [LoggedIn("Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteLocale.Execute(id);
                return StatusCode(204);
            }
            catch(NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
