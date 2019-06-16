using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using Application.Commands.LocaleTypeCommands;
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
    public class LocaleTypeController : ControllerBase
    {

        private readonly IAddLocaleTypeCommand _addLocaleType;
        private readonly IGetLocaleTypesCommand _getLocaleTypes;
        private readonly IGetLocaleTypeCommand _getLocaleType;
        private readonly IEditLocaleTypeCommand _editLocaleType;
        private readonly IDeleteLocaleTypeCommand _deleteLocaleType;
        private readonly LoggedUser _user;



        public LocaleTypeController(IAddLocaleTypeCommand addLocaleType, IGetLocaleTypesCommand getLocaleTypes, IGetLocaleTypeCommand getLocaleType, IEditLocaleTypeCommand editLocaleType, IDeleteLocaleTypeCommand deleteLocaleType, LoggedUser user)
        {
            _addLocaleType = addLocaleType;
            _getLocaleTypes = getLocaleTypes;
            _getLocaleType = getLocaleType;
            _editLocaleType = editLocaleType;
            _deleteLocaleType = deleteLocaleType;
            _user = user;
        }

        // GET: api/LocaleType
        [HttpGet]
        public ActionResult<PagedResponse<ShowLocaleTypeDto>> Get([FromQuery] LocaleTypeQuery query)
        {
            return Ok(_getLocaleTypes.Execute(query));            
        }

        // GET: api/LocaleType/5
        [HttpGet("{id}")]
        public ActionResult<ShowLocaleTypeDto> Get(int id)
        {
            try
            {
                return Ok(_getLocaleType.Execute(id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // POST: api/LocaleType
        [LoggedIn("Administrator")]
        [HttpPost]

        public IActionResult Post([FromBody] LocaleTypeDto dto)
        {
            try
            {
                _addLocaleType.Execute(dto);
                return StatusCode(201);
            }
            catch (EntityAlreadyExistsException e)
            {
                return StatusCode(422, e.Message);
            }
        }

        // PUT: api/LocaleType/5
        [LoggedIn("Administrator")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LocaleTypeDto dto)
        {
            try
            {
                dto.Id = id;
                _editLocaleType.Execute(dto);
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
                _deleteLocaleType.Execute(id);
                return StatusCode(204);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
