using BandManager.Api.Resources.Interfaces.IRepositories;

namespace BandManager.Api.BLL.Services
{
	public class FileService : DirectDbService<Resources.Models.File>
	{
		public FileService(IDirectDbRepository<Resources.Models.File> repository) : base(repository)
		{
		}
	}
}
