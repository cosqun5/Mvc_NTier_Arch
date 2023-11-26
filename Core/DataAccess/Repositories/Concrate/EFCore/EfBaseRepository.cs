﻿using Core.DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Repositories.Concrate.EFCore
{
	public abstract class EfBaseRepository<TEntity, TContext> : IBaseRepository<TEntity> where TEntity : class, new() where TContext : DbContext
	{
		private readonly TContext _context;
		private readonly DbSet<TEntity> _dbSet;

		protected EfBaseRepository(TContext context)
		{
			_context = context;
			_dbSet = _context.Set<TEntity>();
		}

		public async Task Insert(TEntity entity)
		{
			await _dbSet.AddAsync(entity);
		}

		public void Delete(TEntity entity)
		{
			_dbSet.Remove(entity);
		}

		public Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null, params string[] includes)
		{
			IQueryable<TEntity> query = GetQuery(includes);
			return filter == null
				? query.ToListAsync()
				: query.Where(filter).ToListAsync();
		}

		public async Task<TEntity> GetById(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		public async Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> filter)
		{
			return await _dbSet.AnyAsync(filter);
		}

		public async Task<int> SaveAsync()
		{
			return await _context.SaveChangesAsync();
		}

		public void Update(TEntity entity)
		{
			_dbSet.Update(entity);
		}

		private IQueryable<TEntity> GetQuery(string[] includes)
		{
			IQueryable<TEntity> query = _dbSet;
			foreach (var item in includes)
			{
				query = query.Include(item);
			}

			return query;
		}

		
	}
}
