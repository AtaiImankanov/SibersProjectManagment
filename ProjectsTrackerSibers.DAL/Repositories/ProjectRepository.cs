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
        public Task<bool> Create(Project entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Project entity)
        {
            throw new NotImplementedException();
        }

        public Task<Project> Get(Guid id)
        {
            throw new NotImplementedException();
        }
 
        public async Task<IEnumerable<Project>> Select()
        {
            return await _db.Projects.ToListAsync();
        }
    }
}
