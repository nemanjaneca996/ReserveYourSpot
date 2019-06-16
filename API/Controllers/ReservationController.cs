using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using Application.Commands.ReservationCommands;
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
    public class ReservationController : ControllerBase
    {
        private readonly IAddReservationCommand _addReservation;
        private readonly IEditReservationCommand _editReservation;
        private readonly IDeleteReservationCommand _deleteReservation;
        private readonly IGetReservationCommand _getReservation;
        private readonly IGetReservationsCommand _getReservations;
        private readonly LoggedUser _user;



        public ReservationController(IAddReservationCommand addReservation, IEditReservationCommand editReservation, IDeleteReservationCommand deleteReservation, IGetReservationCommand getReservation, IGetReservationsCommand getReservations, LoggedUser user)
        {
            _addReservation = addReservation;
            _editReservation = editReservation;
            _deleteReservation = deleteReservation;
            _getReservation = getReservation;
            _getReservations = getReservations;
            _user = user;
        }

        // GET: api/Reservation
        [HttpGet]
        public ActionResult<PagedResponse<ShowReservationDto>> Get([FromQuery] ReservationQuery query)
        {
            return Ok(_getReservations.Execute(query));
        }

        // GET: api/Reservation/5
        [HttpGet("{id}")]
        public ActionResult<ShowReservationDto> Get(int id)
        {
            try
            {
                return Ok(_getReservation.Execute(id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            
        }

        // POST: api/Reservation
        [LoggedIn("User")]
        [HttpPost]
        public IActionResult Post([FromBody] ReservationDto dto)
        {
            try
            {
                _addReservation.Execute(dto);
                return StatusCode(201);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (EntityAlreadyExistsException e)
            {
                return StatusCode(422, e.Message);
            }
            catch (ReservationException e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT: api/Reservation/5
        [LoggedIn("User")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ReservationDto dto)
        {
            try
            {
                dto.Id = id;
                _editReservation.Execute(dto);
                return StatusCode(204);
            }
            catch (ReservationException e)
            {
                return StatusCode(422, e.Message);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [LoggedIn("Users")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteReservation.Execute(id);
                return StatusCode(204);
            }
            catch (ReservationException e)
            {
                return StatusCode(422, e);
            }
            catch (NotFoundException e)
            {
                return NotFound(e);
            }
        }
    }
}
