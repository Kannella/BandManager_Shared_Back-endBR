using BandManager.Api.BLL.Services;
using BandManager.Api.DAL.Context;
using BandManager.Api.DAL.Repositories;
using BandManager.Api.Resources.Models;
using Microsoft.AspNetCore.Mvc;

namespace BandManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandUserController : DirectDbController<BandUser>
    {
        private readonly BandUserService _bandUserService;

        public BandUserController(BandManagerContext context) : base(context)
        {
            _bandUserService = new BandUserService(new DirectDbRepository<BandUser>(context));
        }

        [HttpPost("AddUserToBand")]
        public IActionResult AddUserToBand([FromBody] BandUser bandUser)
        {
            try
            {
                if (bandUser == null)
                {
                    return BadRequest("BandUser object is null.");
                }

                _bandUserService.AddUserToBand(bandUser);
                return Ok("User added to band successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while adding the user to the band: " + ex.Message);
            }
        }




        [HttpDelete("RemoveUserFromBand")]
        public IActionResult RemoveUserFromBand(int bandId, int userId)
        {
            try
            {
                _bandUserService.RemoveUserFromBand(bandId, userId); // Passando bandId e userId como argumentos
                return Ok("User removed from band successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while removing the user from the band: " + ex.Message);
            }
        }



    }
}
