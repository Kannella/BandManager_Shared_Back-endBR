using BandManager.Api.BLL.Services;
using BandManager.Api.Resources.Interfaces.IRepositories;
using BandManager.Api.Resources.Models;

namespace BandManager.Api.BLL.Services
{
    public class BandUserService : DirectDbService<BandUser>, IBandUserRepository
    {   
        public BandUserService(IDirectDbRepository<BandUser> repository) : base(repository)
        {
        }

        public void AddUserToBand(BandUser bandUser)
        {
            if (bandUser == null || bandUser.BandId <= 0 || bandUser.UserId <= 0)
            {
                throw new ArgumentException("Invalid BandId or UserId.");
            }

            Create(bandUser); // Insere no banco de dados
        }


        public void RemoveUserFromBand(int bandId, int userId)
        {
            var bandUser = GetWhere(bu => bu.BandId == bandId && bu.UserId == userId).FirstOrDefault();

            if (bandUser == null)
            {
                throw new KeyNotFoundException("The specified user is not part of this band.");
            }

            Delete(bandUser);
        }
    }
}
