using BandManager.Api.DAL.Context;
using BandManager.Api.Resources.Interfaces.IRepositories;

namespace BandManager.Api.DAL.Repositories
{
	public class TaskRepository : DirectDbRepository<Resources.Models.Task>, ITaskRepository
	{
		public TaskRepository(BandManagerContext context) : base(context)
		{
		}
	}
}