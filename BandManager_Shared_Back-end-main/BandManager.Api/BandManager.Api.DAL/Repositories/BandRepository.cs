using BandManager.Api.DAL.Context;
using BandManager.Api.Resources.Models;
using BandManager.Api.Resources.Interfaces.IRepositories;

namespace BandManager.Api.DAL.Repositories
{
	public class BandRepository : DirectDbRepository<Band>, IBandRepository
	{
		public BandRepository(BandManagerContext context) : base(context)
		{
		}
	}
}
