using BandManager.Api.DAL.Context;
using BandManager.Api.Resources.Models;
using BandManager.Api.Resources.Interfaces.IRepositories;

namespace BandManager.Api.DAL.Repositories
{
	public class VenueRepository : DirectDbRepository<Venue>, IVenueRepository
	{
		public VenueRepository(BandManagerContext context) : base (context)
		{
		}
	}
}
