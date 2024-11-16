using BandManager.Api.DAL.Context;
using BandManager.Api.Resources.Interfaces.IRepositories;
using BandManager.Api.Resources.Models;

namespace BandManager.Api.DAL.Repositories
{
	public class BandUserRepository : DirectDbRepository<BandUser>, IBandUserRepository
	{
		public BandUserRepository(BandManagerContext context) : base(context)
		{
		}
	}
}