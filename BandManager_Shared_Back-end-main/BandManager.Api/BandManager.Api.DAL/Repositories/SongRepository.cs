using BandManager.Api.DAL.Context;
using BandManager.Api.Resources.Interfaces.IRepositories;
using BandManager.Api.Resources.Models;

namespace BandManager.Api.DAL.Repositories
{
	public class SongRepository : DirectDbRepository<Song>, ISongRepository
	{
		public SongRepository(BandManagerContext context) : base(context)
		{
		}
	}
}