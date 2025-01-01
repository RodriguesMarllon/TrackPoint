using Domain.Entities.Activities;
using Domain.InterfacesRepositories.Abstract;

namespace Domain.InterfacesRepositories.Activities
{
    public interface IActivityRepository : IBaseRepository
    {
        Task<Entities.Activities.Activity> GetById(long id);
        Task<bool> Add(Entities.Activities.Activity obj);
        Task<bool> Update(Entities.Activities.Activity obj);
        Task<bool> Delete(long id);
        Task<List<Entities.Activities.Activity>> GetAll();
    }
}
