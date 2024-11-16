using BandManager.Api.Resources.Interfaces.IRepositories;
using BandManager.Api.Resources.Models;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
namespace BandManager.Api.BLL.Services
{
    public class AvailabilityService : DirectDbService<Availability>
    {
        private readonly IDirectDbRepository<Availability> _repository;

        public AvailabilityService(IDirectDbRepository<Availability> repository) : base(repository)
        {
            _repository = repository;
        }

        public bool AddAvailabilityAsync(int musicianId, DateTime availableDate)
        {
            var availability = new Availability
            {
                UserId = musicianId,
                AvailabilityDate = availableDate
            };

            try
            {
                Create(availability);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar disponibilidade: " + ex.Message);
            }
        }
    }
}