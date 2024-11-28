using BandManager.Api.BLL.Services;
using BandManager.Api.DAL.Context;
using BandManager.Api.DAL.Repositories;
using BandManager.Api.Resources.Models;
using Microsoft.AspNetCore.Mvc;
using BandManager.Api.BLL.Utilities;

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
						if (string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(user.Password))
						{
								return BadRequest("Username and password are required.");
						}

						try
						{
								_userService.CreateUser(user);
								return Ok("User created successfully.");
						}
						catch (Exception ex)
						{
								return StatusCode(500, $"Internal server error: {ex.Message}");
						}
				}

				[HttpPost("Login")]
				public IActionResult Login([FromBody] LoginRequest loginRequest)
				{
						if (string.IsNullOrWhiteSpace(loginRequest.Email) || string.IsNullOrWhiteSpace(loginRequest.Password))
						{
								return BadRequest("Email and password are required.");
						}

						try
						{
								var user = _userService.GetByEmail(loginRequest.Email);

								if (user == null)
								{
										return Unauthorized("Invalid Email or password.");
								}

								bool isPasswordValid = PasswordHasher.VerifyPassword(loginRequest.Password, user.Password);

								if (isPasswordValid)
								{
										// Retorna o ID do usuário junto com a mensagem de sucesso
										return Ok(new { message = "Login successful.", userId = user.Id, Role = user.Role });
								}
								else
								{
										return Unauthorized("Invalid Email or password.");
								}
						}
						catch (Exception ex)
						{
								return StatusCode(500, $"Internal server error: {ex.Message}");
						}
				}
    }
}
