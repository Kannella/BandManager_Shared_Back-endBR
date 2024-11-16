using BandManager.Api.BLL.Services;
using BandManager.Api.DAL.Context;
using BandManager.Api.DAL.Repositories;
using BandManager.Api.Resources.Models;
using Microsoft.AspNetCore.Mvc;

namespace BandManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : DirectDbController<Booking>
    {
        private readonly BookingService _bookingService;

        public BookingController(BandManagerContext context) : base(context)
        {
            _bookingService = new BookingService(new BookingRepository(context));
        }

        [HttpPost("ShareOnFacebook/{bookingId}")]
        public IActionResult ShareOnFacebook(int bookingId)
        {
            try
            {
                _bookingService.ShareOnFacebook(bookingId);
                return Ok("Evento compartilhado no Facebook com sucesso.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem("Ocorreu um erro ao compartilhar o evento no Facebook: " + ex.Message);
            }
        }
    }
}