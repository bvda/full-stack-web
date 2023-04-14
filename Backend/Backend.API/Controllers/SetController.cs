using Microsoft.AspNetCore.Mvc;

using Backend.API.Services;

namespace Backend.API.Controller;

[ApiController]
[Route("[controller]")]
public class SetController : ControllerBase
{
  private readonly ILogger<CardController> _logger;
  private readonly ISetService _service;

  public SetController(ISetService service, ILogger<CardController> logger)
  {
    _logger = logger;
    _service = service;
  }

  [HttpGet]
  public async Task<ActionResult<SetDTO>> Get()
  {
    var result = await _service.GetSets();
    return Ok(result);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<SetDTO>> Get(int id)
  {
    var result = await _service.GetSet(id);
    return Ok(result);
  }
}