using BandManager.Api.Resources.Models;

namespace BandManager.Api.Resources.Interfaces
{
    public interface IDirectDbService<E> where E : Entity
    {
		public void Create(E entity);
		public void Delete(E entity);
		public List<E> GetAll(bool includeChildren = false);
		public E GetById(int id, bool includeChildren = true);
		public List<E> GetWhere(Func<E, bool> where, bool includeChildren = false);
		public void Update(E entity);
	}
}
