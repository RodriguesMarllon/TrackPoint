using Domain.Entities.WorkLogs;
using Domain.InterfacesRepositories.Abstract;

namespace Domain.InterfacesRepositories.WorkLogs
{
    public interface IWorkLogRepository : IBaseRepository
    {
        Task<WorkLog> GetById(long id);
        Task<bool> Add(WorkLog obj);
        Task<bool> Update(WorkLog obj);
        Task<bool> Delete(long id);
        Task<List<WorkLog>> GetAll();
    }
}
