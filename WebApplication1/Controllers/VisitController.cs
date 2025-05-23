﻿using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/visits")]
public class VisitController : ControllerBase
{
    private readonly IVisitService _visitService;
    public VisitController(IVisitService visitService)
    {
        _visitService = visitService;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetVisitsAsync(CancellationToken cancellationToken, int id)
    {
        var visits = await _visitService.GetVisitsAsync(id, cancellationToken);
        return Ok(visits);
    }
}