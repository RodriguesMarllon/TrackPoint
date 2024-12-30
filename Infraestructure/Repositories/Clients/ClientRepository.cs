using Domain.Entities.Clients;
using Domain.InterfacesRepositories.Clients;
using Infraestructure.Configuration;
using Infrastructure.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Clients
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        private readonly TrackPointContext _context;

        public ClientRepository(TrackPointContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Client obj)
        {
            _context.Clients.Add(obj);
            await _context.SaveChangesAsync();
            return obj.Id > 0;
        }

        public async Task<bool> AddMultipleItems(List<Client> objs)
        {
            _context.Clients.AddRange(objs);
            await _context.SaveChangesAsync();
            return (objs?.FirstOrDefault()?.Id ?? 0) > 0;
        }

        public async Task<bool> Delete(long id)
        {
            var entityToDelete = await GetById(id);
            if (entityToDelete != null)
            {
                _context.Clients.Remove(entityToDelete);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> TruncateTable()
        {
            string tableName = nameof(_context.Clients);
            await _context.Database.ExecuteSqlRawAsync($"TRUNCATE TABLE {tableName}; DBCC CHECKIDENT ('{tableName}', RESEED, 1);");
            return true;
        }

        public async Task<List<Client>> GetAll()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetById(long id)
        {
            return await _context.Clients.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> Update(Client obj)
        {
            _context.Clients.Update(obj);
            await _context.SaveChangesAsync();
            return obj.Id > 0;
        }
    }
}