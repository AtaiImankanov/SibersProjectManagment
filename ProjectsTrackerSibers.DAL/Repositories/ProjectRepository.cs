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
    public class ProjectRepository : IProjectRepository
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

        public async Task<Project> Get(Guid id)
        {
            return await _db.Projects.FirstOrDefaultAsync(x => x.Id == id);
        }
 
        public async Task<IEnumerable<Project>> Select()
        {
            return await _db.Projects.ToListAsync();
        }
    }
}
