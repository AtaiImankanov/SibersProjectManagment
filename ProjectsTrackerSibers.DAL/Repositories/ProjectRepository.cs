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
    public class ProjectRepository : IBaseRepository<Project>
    {
        private readonly AppDbContext _db;
        public ProjectRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(Project entity)
        {
        //TODO try catch(false)
            await _db.Projects.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(Project entity)
        {     
             _db.Projects.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
        public IQueryable<Project> GetAll()
        {
            return  _db.Projects;
        }

        public async Task<bool> Edit(Project entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
