using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using Application.Commands.LocaleTableCommands;
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
    public class LocaleTableController : ControllerBase
    {
        private readonly IAddLocaleTableCommand _addLocaleTable;
        private readonly IGetLocaleTablesCommand _getLocaleTables;
        private readonly IGetLocaleTableCommand _getLocaleTable;
        private readonly IDeleteLocaleTableCommand _deleteLocaleTable;
        private readonly IEditLocaleTableCommand _editLocaleTable;
        private readonly LoggedUser _user;


        public LocaleTableController(IAddLocaleTableCommand addLocaleTable, IGetLocaleTablesCommand getLocaleTables, IGetLocaleTableCommand getLocaleTable, IDeleteLocaleTableCommand deleteLocaleTable, IEditLocaleTableCommand editLocaleTable, LoggedUser user)
        {
            _addLocaleTable = addLocaleTable;
            _getLocaleTables = getLocaleTables;
            _getLocaleTable = getLocaleTable;
            _deleteLocaleTable = deleteLocaleTable;
            _editLocaleTable = editLocaleTable;
            _user = user;
        }

        // GET: api/LocaleTable
        [HttpGet]
        public ActionResult<PagedResponse<ShowLocaleTableDto>> Get([FromQuery] LocaleTableQuery query)
        {
            return Ok(_getLocaleTables.Execute(query));
        }

        // GET: api/LocaleTable/5
        [HttpGet("{id}")]
        public ActionResult<ShowLocaleTableDto> Get(int id)
        {
            try
            {
                return Ok(_getLocaleTable.Execute(id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // POST: api/LocaleTable
        [LoggedIn("Administrator")]
        [HttpPost]
        public IActionResult Post([FromBody] LocaleTableDto dto)
        {
            try
            {
                _addLocaleTable.Execute(dto);
                return StatusCode(201);
            }
            catch (EntityAlreadyExistsException e)
            {
                return StatusCode(422, e.Message);
            }
        }

        // PUT: api/LocaleTable/5
        [LoggedIn("Administrator")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LocaleTableDto dto)
        {
            try
            {
                dto.Id = id;
                _editLocaleTable.Execute(dto);
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
                _deleteLocaleTable.Execute(id);
                return StatusCode(204);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
