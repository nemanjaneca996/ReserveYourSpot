using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.ReviewCommands;
using Application.DTO;
using Application.Exceptions;
using Application.Queries;
using Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {

        private readonly IAddReviewCommand _addReview;
        private readonly IEditReviewCommand _editReview;
        private readonly IDeleteReviewCommand _deleteReview;
        private readonly IGetReviewCommand _getReview;
        private readonly IGetReviewsCommand _getReviews;

        public ReviewController(IAddReviewCommand addReview, IEditReviewCommand editReview, IDeleteReviewCommand deleteReview, IGetReviewCommand getReview, IGetReviewsCommand getReviews)
        {
            _addReview = addReview;
            _editReview = editReview;
            _deleteReview = deleteReview;
            _getReview = getReview;
            _getReviews = getReviews;
        }



        // GET: api/Review
        [HttpGet]
        public ActionResult<PagedResponse<ShowReviewDto>> Get([FromQuery] ReviewQuery query)
        {
            return Ok(_getReviews.Execute(query));
        }

        // GET: api/Review/5
        [HttpGet("{id}")]
        public ActionResult<ShowReviewDto> Get(int id)
        {
            try
            {
                return Ok(_getReview.Execute(id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // POST: api/Review
        [HttpPost]
        public IActionResult Post([FromBody] ReviewDto dto)
        {
            try
            {
                _addReview.Execute(dto);
                return StatusCode(201);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // PUT: api/Review/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EditReviewDto dto)
        {
            dto.Id = id;
            _editReview.Execute(dto);
            return StatusCode(204);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteReview.Execute(id);
                return StatusCode(204);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
