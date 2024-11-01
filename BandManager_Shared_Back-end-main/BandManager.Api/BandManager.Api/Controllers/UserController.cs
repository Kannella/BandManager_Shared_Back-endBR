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
	public class UserController : ControllerBase
	{
		private readonly UserService _userService;

		public UserController(IConfiguration configuration)
		{
			 _userService = new UserService(new UserRepository(new BandManagerContext(new AppConfiguration(configuration))));
		}


		[HttpGet("User/{id}")]
		public IActionResult Get(int id)
        {
            // Chama o método do serviço para obter o usuário
            var user = _userService.GetUserById(id); // Presumindo que esse método exista no UserService

            if (user == null)
            {
                return NotFound(); // Retorna 404 se o usuário não for encontrado
            }

            return Ok(user); // Retorna 200 com o usuário
        }

        [HttpPost("User")]
        public IActionResult CreateUser([FromBody] User user)
        {
            // Validação dos dados pode ser feita aqui, se necessário

            _userService.CreateUser(user);

            return Ok("Usuário criado com sucesso!"); // Retorna 200 ao final do cadastro
        }

    }
}
