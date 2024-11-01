using BandManager.Api.DAL.Context;
using BandManager.Api.Resources.Models;
using BandManager.Api.Resources.Interfaces.IRepositories;

namespace BandManager.Api.DAL.Repositories
{
	public class UserRepository : DirectDbRepository<User>, IUserRepository
	{
		public UserRepository(BandManagerContext context) : base(context)
		{
		}
	}
}
