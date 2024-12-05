using Microsoft.EntityFrameworkCore;
using RaspberryPuppy.EFDbContext;
using RaspberryPuppy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspberryPuppy
{
	public class GenericPuppyRepo<T> : IGenericPuppyRepo<T> where T : class
	{
		private readonly PuppyDbContext _context;
		private readonly DbSet<T> _dbSet;

		public GenericPuppyRepo()
		{
			_context = new PuppyDbContext();
			_context.Database.EnsureCreated();
			_dbSet = _context.Set<T>();
		}

		public List<T> GetAll()
		{
			return _dbSet.ToList();
		}

		public T GetByID(int? id)
		{
			var entity = _dbSet.Find(id);
			if (entity == null)
			{
				throw new ArgumentNullException("No item exists with this id");
			}
			return entity;
		}

		public T Add(T item)
		{
			_dbSet.Add(item);
			_context.SaveChanges();
			return item;
		}

		public T? Update(int id, T item)
		{
			var entity = _dbSet.Find(id);
			if (entity != null)
			{
				_context.Entry(entity).CurrentValues.SetValues(item);
				_context.SaveChanges();
			}
			return entity;
		}

		public T? Delete(int id)
		{
			var entity = _dbSet.Find(id);
			if (entity != null)
			{
				_dbSet.Remove(entity);
				_context.SaveChanges();
			}
			return entity;
		}
	}
}
