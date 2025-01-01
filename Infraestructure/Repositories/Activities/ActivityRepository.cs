using Domain.Entities.Activities;
using Domain.InterfacesRepositories.Activities;
using Infraestructure.Configuration;
using Infrastructure.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Activities
{
    public class ActivityRepository : BaseRepository<Domain.Entities.Activities.Activity>, IActivityRepository
    {
        private readonly TrackPointContext _context;

        public ActivityRepository(TrackPointContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Domain.Entities.Activities.Activity obj)
        {
            _context.Activities.Add(obj);
            await _context.SaveChangesAsync();
            return obj.Id > 0;
        }

        public async Task<bool> AddMultipleItems(List<Domain.Entities.Activities.Activity> objs)
        {
            _context.Activities.AddRange(objs);
            await _context.SaveChangesAsync();
            return (objs?.FirstOrDefault()?.Id ?? 0) > 0;
        }

        public async Task<bool> Delete(long id)
        {
            var entityToDelete = await GetById(id);
            if (entityToDelete != null)
            {
                _context.Activities.Remove(entityToDelete);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> TruncateTable()
        {
            string tableName = nameof(_context.Activities);
            await _context.Database.ExecuteSqlRawAsync($"TRUNCATE TABLE {tableName}; DBCC CHECKIDENT ('{tableName}', RESEED, 1);");
            return true;
        }

        public async Task<List<Domain.Entities.Activities.Activity>> GetAll()
        {
            return await _context.Activities.ToListAsync();
        }

        public async Task<Domain.Entities.Activities.Activity> GetById(long id)
        {
            return await _context.Activities.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> Update(Domain.Entities.Activities.Activity obj)
        {
            _context.Activities.Update(obj);
            await _context.SaveChangesAsync();
            return obj.Id > 0;
        }
    }
}
