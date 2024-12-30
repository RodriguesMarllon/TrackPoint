using Domain.Entities.Projects;
using Domain.InterfacesRepositories.Projects;
using Infraestructure.Configuration;
using Infrastructure.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Projects
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        private readonly TrackPointContext _context;

        public ProjectRepository(TrackPointContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Project obj)
        {
            _context.Projects.Add(obj);
            await _context.SaveChangesAsync();
            return obj.Id > 0;
        }

        public async Task<bool> AddMultipleItems(List<Project> objs)
        {
            _context.Projects.AddRange(objs);
            await _context.SaveChangesAsync();
            return (objs?.FirstOrDefault()?.Id ?? 0) > 0;
        }

        public async Task<bool> Delete(long id)
        {
            var entityToDelete = await GetById(id);
            if (entityToDelete != null)
            {
                _context.Projects.Remove(entityToDelete);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> TruncateTable()
        {
            string tableName = nameof(_context.Projects);
            await _context.Database.ExecuteSqlRawAsync($"TRUNCATE TABLE {tableName}; DBCC CHECKIDENT ('{tableName}', RESEED, 1);");
            return true;
        }

        public async Task<List<Project>> GetAll()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetById(long id)
        {
            return await _context.Projects.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> Update(Project obj)
        {
            _context.Projects.Update(obj);
            await _context.SaveChangesAsync();
            return obj.Id > 0;
        }
    }
}
