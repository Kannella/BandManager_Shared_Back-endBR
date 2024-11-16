using BandManager.Api.Resources.Interfaces.IRepositories;
using BandManager.Api.Resources.Models;

namespace BandManager.Api.BLL.Services
{
	public class UserService : DirectDbService<User>
	{
		public UserService(IDirectDbRepository<User> repository) : base(repository)
		{
		}

        public void CreateUser(User user)
        {
            Create(user); // Chama o m�todo da classe base para inserir o usu�rio
        }
    }
}
