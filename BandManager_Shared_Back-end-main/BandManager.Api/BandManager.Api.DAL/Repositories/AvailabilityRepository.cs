using BandManager.Api.DAL.Context;
using BandManager.Api.Resources.Interfaces.IRepositories;
using BandManager.Api.Resources.Models;

namespace BandManager.Api.DAL.Repositories
{
    public class AvailabilityRepository : DirectDbRepository<Availability>, IAvailabilityRepository
    {
        public AvailabilityRepository(BandManagerContext context) : base(context)
        {
        }
    }
}