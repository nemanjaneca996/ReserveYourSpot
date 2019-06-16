using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using Application.Commands;
using Application.Commands.RoleCommands;
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
    public class RoleController : ControllerBase
    {

        private readonly IGetRoleCommand _getRole;
        private readonly IGetRolesCommand _getRoles;
        private readonly IAddRoleCommand _addRole;
        private readonly IDeleteRoleCommand _deleteRole;
        private readonly IEditRoleCommand _editRole;
        private readonly LoggedUser _user;

        public RoleController(IGetRoleCommand getRole, IGetRolesCommand getRoles, IAddRoleCommand addRole, IDeleteRoleCommand deleteRole, IEditRoleCommand editRole, LoggedUser user)
        {
            _getRole = getRole;
            _getRoles = getRoles;
            _addRole = addRole;
            _deleteRole = deleteRole;
            _editRole = editRole;
            _user = user;
        }

        // GET: api/Role
        [LoggedIn("Administrator")]
        [HttpGet]
        public ActionResult<PagedResponse<ShowRoleDto>> Get([FromQuery]RoleQuery query)
        {
            return Ok(_getRoles.Execute(query));
        }

        // GET: api/Role/5
        [LoggedIn("Administrator")]
        [HttpGet("{id}")]
        public ActionResult<ShowRoleDto> Get(int id)
        {
            try
            {
                return Ok(_getRole.Execute(id));
            }
            catch(NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // POST: api/Role
        [LoggedIn("Administrator")]
        [HttpPost]
        public IActionResult Post([FromBody] RoleDto dto)
        {
            try
            {
                _addRole.Execute(dto);
                return StatusCode(201);
            }
            catch (EntityAlreadyExistsException e)
            {
                return StatusCode(422, e.Message);
            }
        }

        // PUT: api/Role/5
        [LoggedIn("Administrator")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RoleDto dto)
        {
            try
            {
                dto.Id = id;
                _editRole.Execute(dto);
                return StatusCode(204);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (EntityAlreadyExistsException e) {
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
                _deleteRole.Execute(id);
                return StatusCode(204);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
