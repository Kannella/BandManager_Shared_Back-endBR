using BandManager.Api.DAL.Context;
using BandManager.Api.Resources.Interfaces.IRepositories;
using BandManager.Api.Resources.Models;

namespace BandManager.Api.DAL.Repositories
{
	public class BookingSongRepository : DirectDbRepository<BookingSong>, IBookingSongRepository
	{
		public BookingSongRepository(BandManagerContext context) : base(context)
		{
		}
	}
}