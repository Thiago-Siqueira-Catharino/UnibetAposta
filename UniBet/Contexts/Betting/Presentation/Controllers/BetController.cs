using Microsoft.AspNetCore.Mvc;
using UniBet.Contexts.Betting.Application.UseCases;
using UniBet.Contexts.Betting.Application.UseCases.CreateBet;
using UniBet.Contexts.Betting.Application.UseCases.GetBet;

namespace UniBet.Contexts.Betting.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class BetController : ControllerBase
{
    private readonly GetBetUseCase _getBetUseCase;
    private readonly CreateBetUseCase _createBetUseCase;

    public BetController(GetBetUseCase getBetUseCase,  CreateBetUseCase createBetUseCase)
    {
        _getBetUseCase = getBetUseCase;
        _createBetUseCase = createBetUseCase;
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

    [HttpPost("CreateBet")]
    public IActionResult CreateBet([FromQuery] CreateBetDTO newBet)
    {
        try
        {
            _createBetUseCase.Run(newBet);
            return Ok("Created");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}