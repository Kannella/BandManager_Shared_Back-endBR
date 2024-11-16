using BandManager.Api.BLL.Services;
using BandManager.Api.DAL.Context;
using BandManager.Api.DAL.Repositories;
using BandManager.Api.Resources.Models;
using Microsoft.AspNetCore.Mvc;

namespace BandManager.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : DirectDbController<User>
	{
		private readonly UserService _userService;

		public UserController(BandManagerContext context) : base(context) 
		{
			 _userService = new UserService(new UserRepository(context));
		}

        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] User user)
        {
            // Validação dos dados pode ser feita aqui, se necessário

            _userService.CreateUser(user);

            return Ok("Usuário criado com sucesso!"); // Retorna 200 ao final do cadastro
        }
    }
}
