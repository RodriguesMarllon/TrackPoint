using Domain.Entities.Employees;
using Domain.Entities.Employees;
using Domain.InterfacesRepositories.Employees;
using Infraestructure.Configuration;
using Infrastructure.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Employees
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly TrackPointContext _context;

        public EmployeeRepository(TrackPointContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Employee obj)
        {
            _context.Employees.Add(obj);
            await _context.SaveChangesAsync();
            return obj.Id > 0;
        }

        public async Task<bool> AddMultipleItems(List<Employee> objs)
        {
            _context.Employees.AddRange(objs);
            await _context.SaveChangesAsync();
            return (objs?.FirstOrDefault()?.Id ?? 0) > 0;
        }

        public async Task<bool> Delete(long id)
        {
            var entityToDelete = await GetById(id);
            if (entityToDelete != null)
            {
                _context.Employees.Remove(entityToDelete);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> TruncateTable()
        {
            string tableName = nameof(_context.Employees);
            await _context.Database.ExecuteSqlRawAsync($"TRUNCATE TABLE {tableName}; DBCC CHECKIDENT ('{tableName}', RESEED, 1);");
            return true;
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(long id)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> Update(Employee obj)
        {
            _context.Employees.Update(obj);
            await _context.SaveChangesAsync();
            return obj.Id > 0;
        }
    }
}
