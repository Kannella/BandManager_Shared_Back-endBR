using BandManager.Api.Resources.Interfaces.IRepositories;
using BandManager.Api.Resources.Models;

namespace BandManager.Api.BLL.Services
{
	public class VenueService : DirectDbService<Venue>
	{
		public VenueService(IDirectDbRepository<Venue> repository) : base(repository)
		{
		}
	}
}
