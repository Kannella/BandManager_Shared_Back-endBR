using BandManager.Api.Resources.Interfaces.IRepositories;
using BandManager.Api.Resources.Models;
using System.Security.Cryptography.X509Certificates;

namespace BandManager.Api.BLL.Services
{
	public class VenueService : DirectDbService<Venue>
	{
		public VenueService(IDirectDbRepository<Venue> repository) : base(repository)
		{

		}

		public void DeleteByID(int id)
		{
			Venue venue = GetById(id);
			Delete(venue);
		}
	}
}
