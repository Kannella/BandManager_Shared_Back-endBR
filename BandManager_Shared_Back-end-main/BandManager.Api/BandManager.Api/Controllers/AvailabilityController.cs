using BandManager.Api.BLL.Services;
using BandManager.Api.DAL.Context;
using BandManager.Api.DAL.Repositories;
using BandManager.Api.Resources.Models;
using Microsoft.AspNetCore.Mvc;

namespace BandManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilityController : DirectDbController<Availability>
    {
        private readonly AvailabilityService _availabilityService;

        public AvailabilityController(BandManagerContext context) : base(context)
        {
            _availabilityService = new AvailabilityService(new DirectDbRepository<Availability>(context));
        }

        [HttpPost("AddAvailability")]
        public IActionResult AddAvailability([FromBody] Availability availability)
        {
            if (availability == null || availability.UserId == 0 || availability.AvailabilityDate == default)
            {
                return BadRequest("Dados inválidos.");
            }

            Console.WriteLine($"Received: UserId={availability.UserId}, AvailabilityDate={availability.AvailabilityDate}");

            try
            {
                bool success = _availabilityService.AddAvailabilityAsync(availability.UserId, availability.AvailabilityDate);

                if (success)
                {
                    return Ok("Disponibilidade registrada com sucesso!");
                }

                return StatusCode(500, "Erro ao registrar disponibilidade.");
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }


    }
}