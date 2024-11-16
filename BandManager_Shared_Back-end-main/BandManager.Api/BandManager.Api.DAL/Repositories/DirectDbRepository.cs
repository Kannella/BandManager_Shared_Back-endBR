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

		public List<E> GetAll(bool includeChildren = false)
		{
			switch (includeChildren)
			{
				case true:
					return _dbSet.ToList();
				case false:
					return _dbSet.IgnoreAutoIncludes().ToList();
			}
		}

		public E GetById(int id, bool includeChildren = true)
		{
			return GetWhere(e => e.Id == id, includeChildren).FirstOrDefault();
		}

		public List<E> GetWhere(Func<E, bool> where, bool includeChildren = false)
		{
			switch (includeChildren)
			{
				case true:
					return _dbSet.Where(where).ToList();
				case false:
					return _dbSet.IgnoreAutoIncludes().Where(where).ToList();
			}
		}

		public void Update(E entity)
		{
			_dbSet.Update(entity);
			_context.SaveChanges();
		}
	}
}