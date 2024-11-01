using BandManager.Api.Resources.Interfaces.IRepositories;
using BandManager.Api.Resources.Models;

namespace BandManager.Api.BLL.Services
{
	public class BandService : DirectDbService<Band>
	{
		public BandService(IDirectDbRepository<Band> repository) : base(repository)
		{
		}
	}
}
