using Microsoft.AspNetCore.Mvc;
using UniBet.Contexts.Betting.Application.UseCases.GetBet;

namespace UniBet.Contexts.Betting.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class BetController : ControllerBase
{
    private readonly GetBetUseCase _getBetUseCase;

    public BetController(GetBetUseCase getBetUseCase)
    {
        _getBetUseCase = getBetUseCase;
    }
    
    [HttpGet("{Id}")]
    public IActionResult GetBetById(Guid Id)
    {
        try
        {
            var request = new GetBetRequest(Id);
            GetBetResponse response = _getBetUseCase.Run(request);
            
            return Ok(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return NotFound();
        }
    }
}