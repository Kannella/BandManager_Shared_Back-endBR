using BandManager.Api.Resources.Models;

namespace BandManager.Api.Resources.Interfaces.IRepositories
{
    public interface IDirectDbRepository<E> where E : Entity
    {
		public void Create(E entity);
		public void Delete(E entity);
		public List<E> GetAll(bool includeChildren = false);
		public E GetById(int id, bool includeChildren = true); // technically not usefull because of GetWhere(), but nice to have
		public List<E> GetWhere(Func<E, bool> where, bool includeChildren = false);
		public void Update(E entity);
	}
}
