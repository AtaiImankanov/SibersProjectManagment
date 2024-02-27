using Microsoft.EntityFrameworkCore;
using ProjectsTrackerSibers.DAL.Interfaces;
using ProjectsTrackerSibers.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsTrackerSibers.DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>    where T : class
	{
        private readonly AppDbContext _db;
        
		public BaseRepository(AppDbContext db)
        {
            _db = db;
        }   
        public async Task<bool> Create(T entity)
        {
        //TODO try catch(false)
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(T entity)
        {     
             _db.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public  IQueryable<T> GetAll()
        {
            return _db.Set<T>();
        }

        public async Task<bool> Edit(T entity)
        { 
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<T> Get(Guid i)
        {
			return await _db.Set<T>().FindAsync(i);
		}
    }
}
