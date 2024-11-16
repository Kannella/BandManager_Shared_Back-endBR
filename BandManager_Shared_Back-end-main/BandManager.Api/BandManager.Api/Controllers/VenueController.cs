using BandManager.Api.BLL.Services;
using BandManager.Api.DAL.Context;
using BandManager.Api.DAL.Repositories;
using BandManager.Api.Resources.DTOs;
using BandManager.Api.Resources.Models;
using Microsoft.AspNetCore.Mvc;

namespace BandManager.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VenueController : DirectDbController<Venue>
	{
		private readonly VenueService _venueService;

		public VenueController(BandManagerContext context) : base(context)
		{
			_venueService = new VenueService(new VenueRepository(context));
		}

		[HttpPost]
		public IActionResult CreateVenue(VenueDTO venueDTO)
		{
			try
			{
				Venue venue = new()
				{
					ContactEmail = venueDTO.ContactEmail,
					ContactName = venueDTO.ContactName,
					ContactPhoneNumber = venueDTO.ContactPhoneNumber
				};

				_venueService.Create(venue);
				return Ok();
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public IActionResult EditVenue(int id, VenueDTO venueDTO)
		{
			try
			{
                Venue venue = new()
                {
					Id = id,
                    ContactEmail = venueDTO.ContactEmail,
                    ContactName = venueDTO.ContactName,
                    ContactPhoneNumber = venueDTO.ContactPhoneNumber
                };

                _venueService.Update(venue);
				return Ok();
			}
			catch (ArgumentException ex)
			{
                return BadRequest(ex.Message);
            }
        }
	}
}