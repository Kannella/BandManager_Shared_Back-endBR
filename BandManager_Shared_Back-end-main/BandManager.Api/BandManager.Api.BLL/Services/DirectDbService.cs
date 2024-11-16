using BandManager.Api.Resources.Models;
using BandManager.Api.Resources.Interfaces.IRepositories;
using BandManager.Api.Resources.Interfaces;
using BandManager.Api.Resources.Exceptions;

namespace BandManager.Api.BLL.Services
{
    public class DirectDbService<E> : IDirectDbService<E> where E : Entity
    {
        private readonly IDirectDbRepository<E> _repository;

        public DirectDbService(IDirectDbRepository<E> repository)
        {
            _repository = repository;
        }

        public virtual void Create(E entity)
        {
            _repository.Create(entity);
        }

        public void Delete(E entity)
        {
            _repository.Delete(entity);
        }

        public List<E> GetAll(bool includeChildren = false)
        {
            List<E> entities = _repository.GetAll();

			if (entities.Count <= 0 || entities == null)
			{
				throw new NoEntitiesFoundException("No entities found, Is the database table empty?");
			}

            return entities;
		}

        public E GetById(int id, bool includeChildren = true)
        {
            E entity = _repository.GetById(id);
            
            if (entity == null)
            {
                throw new KeyNotFoundException($"{typeof(E).Name} not found");
            }
            
            return entity;
        }

        public List<E> GetWhere(Func<E, bool> where, bool includeChildren = false)
        {
			List<E> entities = _repository.GetWhere(where);

			if (entities.Count <= 0 || entities == null)
			{
				throw new NoEntitiesFoundException("No entities found, No entities seem to match the search criteria");
			}

			return entities;
		}

        public void Update(E entity)
        {
            _repository.Update(entity);
        }


    }
}
