using BandManager.Api.DAL.Context;
using BandManager.Api.Resources.Models;
using BandManager.Api.Resources.Interfaces.IRepositories;

namespace BandManager.Api.DAL.Repositories
{
	public class BookingRepository : DirectDbRepository<Booking>, IBookingRepository
	{
		public BookingRepository(BandManagerContext context) : base (context)
		{
		}
	}
}
