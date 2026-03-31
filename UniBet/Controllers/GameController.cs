using Microsoft.AspNetCore.Mvc;
using UniBet.DTOs.Request;
using UniBet.UseCases;

namespace UniBet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly PlaceUseCase _placeUseCase;

        public GameController(PlaceUseCase placeUseCase)
        {
            _placeUseCase = placeUseCase;
        }

        [HttpPost("Place")]
        public IActionResult Place([FromBody] PlaceRequest request)
        {
            try
            {
                this._placeUseCase.Run(request);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
