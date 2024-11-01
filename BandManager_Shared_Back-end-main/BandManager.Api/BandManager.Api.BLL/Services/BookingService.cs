using BandManager.Api.Resources.Interfaces.IRepositories;
using BandManager.Api.Resources.Models;

namespace BandManager.Api.BLL.Services
{
	public class BookingService : DirectDbService<Booking>
	{
		public BookingService(IDirectDbRepository<Booking> repository) : base(repository)
		{
		}
	}
}
