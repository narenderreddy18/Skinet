using API.Errors;
using Infrastracture.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseAPIController
    {
        private readonly SkinetContext _skinetContext;

        public BuggyController(SkinetContext skinetContext)
        {
            _skinetContext = skinetContext;
        }

        [HttpGet("notfound")]
        public IActionResult GetNotFound()
        {
            var thing = _skinetContext.Products.Find(67);
            if (thing == null)
            {
                return NotFound(new APIResponse(404));
            }
            return Ok();
        }

        [HttpGet("servererror")]
        public IActionResult GetServerError()
        {
            var thing = _skinetContext.Products.Find(67);
            var abc = thing.ToString();
            return Ok();
        }

        [HttpGet("badrequest")]
        public IActionResult GetBadRequest()
        {
            return BadRequest(new APIResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public IActionResult GetBadRequestID(int id)
        {
            return Ok();
        }
    }
}
