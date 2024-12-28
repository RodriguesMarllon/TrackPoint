using Domain.Entities.Projects;
using Domain.InterfacesRepositories.Abstract;

namespace Domain.InterfacesRepositories.Projects
{
    public interface IProjectRepository : IBaseRepository
    {
        Task<Project> GetById(long id);
        Task<bool> Add(Project obj);
        Task<bool> Update(Project obj);
        Task<bool> Delete(long id);
        Task<List<Project>> GetAll();
    }
}
