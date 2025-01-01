using Domain.Entities.WorkLogs;
using Domain.InterfacesRepositories.WorkLogs;
using Infraestructure.Configuration;
using Infrastructure.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.WorkLogs
{
    public class WorkLogRepository : BaseRepository<WorkLog>, IWorkLogRepository
    {
        private readonly TrackPointContext _context;

        public WorkLogRepository(TrackPointContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(WorkLog obj)
        {
            _context.WorkLogs.Add(obj);
            await _context.SaveChangesAsync();
            return obj.Id > 0;
        }

        public async Task<bool> AddMultipleItems(List<WorkLog> objs)
        {
            _context.WorkLogs.AddRange(objs);
            await _context.SaveChangesAsync();
            return (objs?.FirstOrDefault()?.Id ?? 0) > 0;
        }

        public async Task<bool> Delete(long id)
        {
            var entityToDelete = await GetById(id);
            if (entityToDelete != null)
            {
                _context.WorkLogs.Remove(entityToDelete);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> TruncateTable()
        {
            string tableName = nameof(_context.WorkLogs);
            await _context.Database.ExecuteSqlRawAsync($"TRUNCATE TABLE {tableName}; DBCC CHECKIDENT ('{tableName}', RESEED, 1);");
            return true;
        }

        public async Task<List<WorkLog>> GetAll()
        {
            return await _context.WorkLogs.ToListAsync();
        }

        public async Task<WorkLog> GetById(long id)
        {
            return await _context.WorkLogs.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> Update(WorkLog obj)
        {
            _context.WorkLogs.Update(obj);
            await _context.SaveChangesAsync();
            return obj.Id > 0;
        }
    }
}
