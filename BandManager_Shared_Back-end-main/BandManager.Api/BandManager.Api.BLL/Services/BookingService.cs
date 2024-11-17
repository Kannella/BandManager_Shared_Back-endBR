using BandManager.Api.Resources.Interfaces.IRepositories;
using BandManager.Api.Resources.Models;

namespace BandManager.Api.BLL.Services
{
	public class BookingService : DirectDbService<Booking>
	{
		private readonly IBookingRepository _bookingRepository;
		private readonly IBandRepository _bandRepository;
		private readonly IAgentRepository _agentRepository;
		private readonly IVenueRepository _venueRepository;
		public BookingService(IBookingRepository bookingRepository, IBandRepository bandRepository, IAgentRepository agentRepository, IVenueRepository venueRepository) : base(bookingRepository) //Unsure wether I should use Idirectdb or the acutal interface
		{
			_bookingRepository = bookingRepository;
			_bandRepository = bandRepository;
			_agentRepository = agentRepository;
			_venueRepository = venueRepository;
		}

		public override void Create(Booking booking)
		{
			//Validate whether the keys we are trying to link exist
			_bandRepository.GetById(booking.BandId);
			
			if (booking.AgentId != null)
			{
				_agentRepository.GetById((int)booking.AgentId);
			}

			if (booking.VenueId != null)
			{
				_venueRepository.GetById((int)booking.VenueId);
			}
			
			_bookingRepository.Create(booking);
		}
		
		public void SetIsPublicEvent(int bookingId, bool isPublicEvent)
		{
			Booking booking = _bookingRepository.GetById(bookingId);
			if (booking == null)
			{
				throw new KeyNotFoundException("Booking not found");
			}
			
			booking.IsPublicEvent = isPublicEvent;
			_bookingRepository.Update(booking);
		}

		public void ValidateForeignKeys(Booking booking)
		{
			_bandRepository.GetById(booking.BandId);
			
			if (booking.AgentId != null)
			{
				_agentRepository.GetById((int)booking.AgentId);
			}

			if (booking.VenueId != null)
			{
				_venueRepository.GetById((int)booking.VenueId);
			}
		}
	}
}
