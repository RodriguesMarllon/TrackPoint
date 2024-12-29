using Domain.Entities.Clients;
using Domain.InterfacesRepositories.Abstract;

namespace Domain.InterfacesRepositories.Clients
{
    public interface IClientRepository : IBaseRepository
    {
        Task<Client> GetById(long id);
        Task<bool> Add(Client obj);
        Task<bool> Update(Client obj);
        Task<bool> Delete(long id);
        Task<List<Client>> GetAll();
    }
}
