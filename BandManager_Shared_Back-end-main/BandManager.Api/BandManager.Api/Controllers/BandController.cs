using BandManager.Api.BLL.Services;
using BandManager.Api.DAL.Context;
using BandManager.Api.DAL.Repositories;
using BandManager.Api.Resources.Models;
using Microsoft.AspNetCore.Mvc;

namespace BandManager.Api.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class BandController : DirectDbController<Band>
	{
		private readonly BandService _bandService;

        public BandController(BandManagerContext context) : base(context)
        {
            _bandService = new BandService(new BandRepository(context));
        }

        [HttpPost("CreateBand")]
        public IActionResult CreateBand([FromBody] Band band)
        {
            // Validação dos dados pode ser feita aqui, se necessário

            _bandService.CreateBand(band);

            return Ok("Banda criada com sucesso!"); // Retorna 200 ao final do cadastro
        }
    }
}