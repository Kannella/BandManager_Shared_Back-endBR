using BandManager.Api.DAL.Context;
using BandManager.Api.Resources.Models;
using BandManager.Api.Resources.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace BandManager.Api.DAL.Repositories
{

	public class DirectDbRepository<E> : IDirectDbRepository<E> where E : Entity
	{
		private BandManagerContext _context;
		protected DbSet<E> _dbSet;

		public DirectDbRepository(BandManagerContext context)
		{
			_context = context;
			_dbSet = context.Set<E>();
		}

		public void Create(E entity)
		{
			_dbSet.Add(entity);
			_context.SaveChanges();
		}

		public void Delete(E entity)
		{
			_dbSet.Remove(entity);
			_context.SaveChanges();
		}

		public List<E> GetAll()
		{
			return _dbSet.ToList();
		}

		public E GetById(int id)
		{
			return _dbSet.FirstOrDefault(e => e.Id == id);
		}

		public List<E> GetWhere(Func<E, bool> where)
		{
			return _dbSet.Where(where).ToList();
		}

		public void Update(E entity)
		{
			_dbSet.Update(entity);
			_context.SaveChanges();
		}
	}
}