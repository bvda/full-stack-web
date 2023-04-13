using Microsoft.AspNetCore.Mvc;

using Backend.API.Services;

namespace Backend.API.Controller;

[ApiController]
[Route("[controller]")]
public class CardController : ControllerBase
{
  private readonly ILogger<CardController> _logger;
  private readonly ICardService _service;

  public CardController(ICardService service, ILogger<CardController> logger)
  {
    _logger = logger;
    _service = service;
  }

  [HttpGet]
  public async Task<ActionResult<CardDTO>> Get()
  {
    var result = await _service.GetCards();
    return Ok(result);
  }
  [HttpGet("{id}")]
  public async Task<ActionResult<CardDTO>> Get(int id)
  {
    var result = await _service.GetCard(id);
    if( result == null) {
      return NotFound();
    }
    return Ok(result);
  }

}