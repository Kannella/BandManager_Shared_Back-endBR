using BandManager.Api.BLL.Services;
using BandManager.Api.DAL.Context;
using BandManager.Api.DAL.Repositories;
using BandManager.Api.Resources.DTOs;
using BandManager.Api.Resources.Models;
using Microsoft.AspNetCore.Mvc;

namespace BandManager.Api.Controllers
{
	[Route("api/[controller]")]
	[Produces("application/json")]
	[ApiController]
	public class BookingController : DirectDbController<Booking>
	{
		private readonly BookingService _bookingService;
		private readonly BandManagerContext _context;

		public BookingController(BandManagerContext context) : base(context)
		{
			_context = context;
			_bookingService = new BookingService(new BookingRepository(context), new BandRepository(context), new AgentRepository(context), new VenueRepository(context));
		}

		/// <summary>
		/// Creates a new booking,
		/// </summary>
		/// <remarks>
		///	The fields "name", "bandId", "status" and "isPublicEvent" are required.
		/// </remarks>
		/// <returns></returns>
		/// <response code="200">Booking added successfully</response>
		/// <response code="404">Band, Agent or Venue not found</response>
		/// <response code="500">Internal server error</response>
		[HttpPost]
		public IActionResult CreateBooking([FromBody] BookingDTO bookingDto)
		{
				// Log do payload recebido
				Console.WriteLine("Payload recebido no controller:");
				Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(bookingDto));

				if (!ModelState.IsValid)
				{
						return BadRequest(ModelState);
				}

				var booking = bookingDto.ToEntity();

				Console.WriteLine("Objeto convertido:");
				Console.WriteLine($"Name: {booking.Name}, VenueId: {booking.VenueId}, BandId: {booking.BandId}");

				_bookingService.Create(booking);

				return Ok(booking);
		}
		
		/// <summary>
		/// Updates an existing booking,
		/// </summary>
		/// <remarks>
		/// The fields "name", "bandId", "status" and "isPublicEvent" are required.
		/// </remarks>
		/// <returns></returns>
		/// <response code="200">Booking edited successfully</response>
		/// <response code="404">Booking, Band, Agent or Venue not found</response>
		/// <response code="500">Internal server error</response>
		[HttpPut("{id:int}")]
		public IActionResult Update(int id, [FromBody] BookingDTO bookingDto)
		{
			try
			{
				_bookingService.ValidateForeignKeys(bookingDto.ToEntity());
				
				Booking booking = _bookingService.GetById(id);
				
				booking.Name = bookingDto.Name; //We should probably install a package to make this a tad more clean
				booking.Description = bookingDto.Description;
				booking.BandId = bookingDto.BandId;
				booking.AgentId = bookingDto.AgentId;
				booking.VenueId = bookingDto.VenueId;
				booking.Planning = bookingDto.Planning;
				booking.Status = bookingDto.Status;
				booking.PaymentDetails = bookingDto.PaymentDetails;
				booking.BookingNumber = bookingDto.BookingNumber;
				booking.StageNumber = bookingDto.StageNumber;
				booking.FoodDetails = bookingDto.FoodDetails;
				booking.SoundCheckTime = bookingDto.SoundCheckTime;
				booking.ArrivalTime = bookingDto.ArrivalTime;
				booking.TourbusLeaveTime = bookingDto.TourbusLeaveTime;
				booking.DinnerTime = bookingDto.DinnerTime;
				booking.ChangeOverTime = bookingDto.ChangeOverTime;
				booking.ShowStartTime = bookingDto.ShowStartTime;
				booking.ShowEndTime = bookingDto.ShowEndTime;
				booking.ParkingDetails = bookingDto.ParkingDetails;
				booking.BookingNotes = bookingDto.BookingNotes;
				booking.IsPublicEvent = bookingDto.IsPublicEvent;
				
				_bookingService.Update(booking);
				return Ok("Booking updated successfully");
			}
			catch (KeyNotFoundException ex)
			{
				return NotFound(ex.Message);
			}
			catch (Exception ex)
			{
				return Problem();
			}
		}
		
		/// <summary>
		/// Changes the state of the IsPublicEvent property of a booking,
		/// </summary>
		/// <returns></returns>
		/// <response code="200">Booking added successfully</response>
		/// <response code="404">Booking not found</response>
		/// <response code="500">Internal server error</response>
		[HttpPut("IsPublicEvent/{id:int}")]
		public IActionResult SetIsPublicEvent(int id, [FromBody] bool isPublicEvent)
		{
			try
			{
				_bookingService.SetIsPublicEvent(id, isPublicEvent);
				return Ok(isPublicEvent ? 
					"Booking set to public successfully" : 
					"Booking set to private successfully");
			}
			catch (KeyNotFoundException ex)
			{
				return NotFound(ex.Message);
			}
			catch (Exception ex)
			{
				return Problem();
			}
		}

		[HttpGet("GetBookingsForUser")]
		public IActionResult GetBookingsForUser([FromQuery] int userId)
		{
				try
				{
						// Passo 1: Obter a lista de BandIds associadas ao usuário
						var userBands = _context.Set<BandUser>()
																		.Where(bu => bu.UserId == userId)
																		.Select(bu => bu.BandId)
																		.ToList();

						// Passo 2: Filtrar os bookings com base no BandId do usuário
						var bookings = _context.Set<Booking>()
																		.Where(b => userBands.Contains(b.BandId))
																		.ToList();

						// Retornar os bookings filtrados
						return Ok(bookings);
				}
			catch (Exception ex)
			{
					return Problem(detail: ex.Message); // Passa a mensagem da exceção como uma string
			}
		}

		[HttpGet("GetBandsForUser")]
		public IActionResult GetBandsForUser([FromQuery] int userId)
		{
				try
				{
						// Obter as bandas que o usuário participa
						var bands = _context.Set<BandUser>()
																.Where(bu => bu.UserId == userId)
																.Join(
																		_context.Set<Band>(),
																		bu => bu.BandId,
																		b => b.Id,
																		(bu, b) => new 
																		{
																				b.Id,    // ID da banda
																				b.Name   // Nome da banda
																		}
																)
																.ToList();

						if (!bands.Any())
						{
								return NotFound($"No bands found for user with ID {userId}");
						}

						// Retornar as bandas com ID e nome
						return Ok(bands);
				}
				catch (Exception ex)
				{
						return Problem("An error occurred while retrieving bands for the user", ex.ToString());
				}
		}

		[HttpDelete("{id:int}")]
		public IActionResult RemoveBooking(int id)
		{
				try
				{
						// Usa o método genérico herdado do DirectDbController
						return base.Delete(id);
				}
				catch (KeyNotFoundException ex)
				{
						return NotFound(ex.Message);
				}
				catch (Exception ex)
				{
						return Problem(detail: ex.Message);
				}
		}




	}
}
