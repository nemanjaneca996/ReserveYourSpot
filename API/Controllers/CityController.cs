using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using Application.Commands;
using Application.Commands.CityCommands;
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
    public class CityController : ControllerBase
    {
        private readonly IAddCityCommand _addCity;
        private readonly IGetCitiesCommand _getCities;
        private readonly IGetCityCommand _getCity;
        private readonly IDeleteCityCommand _deleteCity;
        private readonly IEditCityCommand _editCity;
        private readonly LoggedUser _user;

        

        public CityController(IAddCityCommand addCity, IGetCitiesCommand getCities, IGetCityCommand getCity, IDeleteCityCommand deleteCity, IEditCityCommand editCity, LoggedUser user)
        {
            _addCity = addCity;
            _getCities = getCities;
            _getCity = getCity;
            _deleteCity = deleteCity;
            _editCity = editCity;
            _user = user;
        }

        // GET: api/City
        [HttpGet]
        public ActionResult<PagedResponse<ShowCityDto>> Get([FromQuery] CityQuery query)
        {
            return Ok(_getCities.Execute(query));
        }

        // GET: api/City/5
        [HttpGet("{id}")]
        public ActionResult<ShowCityDto> Get(int id)
        {
            try
            {
                return Ok(_getCity.Execute(id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // POST: api/City
        [LoggedIn("Administrator")]
        [HttpPost]
        public IActionResult Post([FromBody] CityDto dto)
        {
            try
            {
                _addCity.Execute(dto);
                return StatusCode(201);
            }
            catch (EntityAlreadyExistsException e)
            {
                return StatusCode(422, e.Message);
            }
        }

        // PUT: api/City/5

        [LoggedIn("Administrator")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CityQuery query)
        {
            try
            {
               
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
                _deleteCity.Execute(id);
                return StatusCode(204);
            }
            catch (NotFoundException e){
                return NotFound(e.Message);
            }
        }
    }
}
