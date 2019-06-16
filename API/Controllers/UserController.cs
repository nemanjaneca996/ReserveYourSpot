using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using Application.Commands.UserCommands;
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
    public class UserController : ControllerBase
    {
        private readonly IGetUsersCommand _getUsers;
        private readonly IGetUserCommand _getUser;
        private readonly IAddUserCommand _addUser;
        private readonly IDeleteUserCommand _deleteUser;
        private readonly IEditUserCommand _editUser;
        private readonly LoggedUser _user;

        public UserController(IGetUsersCommand getUsers, IGetUserCommand getUser, IAddUserCommand addUser, IDeleteUserCommand deleteUser, IEditUserCommand editUser, LoggedUser user)
        {
            _getUsers = getUsers;
            _getUser = getUser;
            _addUser = addUser;
            _deleteUser = deleteUser;
            _editUser = editUser;
            _user = user;
        }

        // GET: api/User
        [LoggedIn("Administrator")]
        [HttpGet]
        public ActionResult<PagedResponse<ShowUserDto>> Get([FromQuery] UserQuery query)
        {
            return Ok(_getUsers.Execute(query));
        }

        // GET: api/User/5
        [LoggedIn("Administrator")]
        [HttpGet("{id}")]
        public ActionResult<ShowUserDto> Get(int id)
        {
            try
            {
                return Ok(_getUser.Execute(id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // POST: api/User
        [LoggedIn("Administrator")]
        [HttpPost]
        public IActionResult Post([FromBody] UserDto query)
        {

            try
            {
                _addUser.Execute(query);
                return StatusCode(204);
            }
            catch (EntityAlreadyExistsException e) {
                return StatusCode(422, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT: api/User/5
        [LoggedIn("Administrator")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserDto dto)
        {
            try
            {
                dto.Id = id;
                _editUser.Execute(dto);
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
                _deleteUser.Execute(id);
                return StatusCode(204);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }


    }
}
