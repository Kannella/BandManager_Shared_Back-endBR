using BandManager.Api.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using BandManager.Api.DAL.Configuration;
using BandManager.Api.DAL.Context;
using BandManager.Api.BLL.Services;
using BandManager.Api.Resources.Models;

namespace BandManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandController : ControllerBase
    {
        private readonly BandService _bandService;

        public BandController(IConfiguration configuration) // Corrigido para BandController
        {
            _bandService = new BandService(new BandRepository(new BandManagerContext(new AppConfiguration(configuration))));
        }

        [HttpPost("Band")]
        public IActionResult CreateBand([FromBody] Band band)
        {
            // Validação dos dados pode ser feita aqui, se necessário

            _bandService.CreateBand(band);

            return Ok("Banda criada com sucesso!"); // Retorna 200 ao final do cadastro
        }
    }
}

