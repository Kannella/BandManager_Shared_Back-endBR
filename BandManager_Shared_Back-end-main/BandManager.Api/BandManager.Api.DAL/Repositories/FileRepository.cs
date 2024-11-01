using BandManager.Api.DAL.Context;
using BandManager.Api.Resources.Interfaces.IRepositories;

namespace BandManager.Api.DAL.Repositories
{
	public class FileRepository : DirectDbRepository<Resources.Models.File>, IFileRepository
	{
		public FileRepository(BandManagerContext context) : base(context)
		{
		}
	}
}
