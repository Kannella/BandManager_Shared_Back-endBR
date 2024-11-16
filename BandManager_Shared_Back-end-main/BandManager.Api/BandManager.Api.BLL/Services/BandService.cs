using BandManager.Api.Resources.Interfaces.IRepositories;
using BandManager.Api.Resources.Models;

namespace BandManager.Api.BLL.Services
{
	public class BandService : DirectDbService<Band>
	{
		public BandService(IDirectDbRepository<Band> repository) : base(repository)
		{
		}

        public void CreateBand(Band band)
        {
            Create(band); // Chama o método da classe base para inserir o usuário
        }


    }
}
