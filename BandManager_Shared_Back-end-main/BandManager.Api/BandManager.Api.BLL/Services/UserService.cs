using BandManager.Api.Resources.Interfaces.IRepositories;
using BandManager.Api.Resources.Models;
using BandManager.Api.BLL.Utilities;

namespace BandManager.Api.BLL.Services
{
	public class UserService : DirectDbService<User>
	{
		public UserService(IDirectDbRepository<User> repository) : base(repository)
		{
		}

    public User GetByEmail(string Email)
    {
        // Usando a classe base para obter o repositório
        return GetAll().FirstOrDefault(u => u.Email == Email);
    }
    

    public void CreateUser(User user)
    {
        // Criptografa a senha antes de salvar no banco de dados
        user.Password = PasswordHasher.HashPassword(user.Password);
        
        // Passa o usuário com a senha criptografada para o repositório salvar
        Create(user);
    }
    
    
    }
}
