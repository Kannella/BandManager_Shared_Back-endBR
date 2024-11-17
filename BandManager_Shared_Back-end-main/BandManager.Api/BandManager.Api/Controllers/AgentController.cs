using BandManager.Api.BLL.Services;
using BandManager.Api.DAL.Context;
using BandManager.Api.DAL.Repositories;
using BandManager.Api.Resources.DTOs;
using BandManager.Api.Resources.Models;
using Microsoft.AspNetCore.Mvc;

namespace BandManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AgentController : DirectDbController<Agent>
{
    private readonly AgentService _agentService;

    public AgentController(BandManagerContext context) : base(context)
    {
        _agentService = new AgentService(new AgentRepository(context));
    }

    /// <summary>
    /// Add a new agent to the database, validates the input data
    /// </summary>
    /// <param name="agent"></param>
    /// <returns></returns>
    /// <response code="204">Agent added successfully</response>
    /// <response code="400">Invalid input data</response>
    /// <response code="500">Internal server error</response>
    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public IActionResult Post([FromBody] AgentDto agent)
    {
        try
        {
            _agentService.ValidateAndAdd(agent.ToEntity());
            return NoContent();
        }
        catch (ArgumentException ex) {
            return BadRequest(ex.Message);
        }
        catch (InvalidOperationException ex) {
            return Conflict(ex.Message);
        }
        catch (Exception ex) {
            return Problem(detail: ex.Message, statusCode:500);
        }
    }
}