using Domain.Entities.Employees;
using Domain.InterfacesRepositories.Abstract;

namespace Domain.InterfacesRepositories.Employees
{
    public interface IEmployeeRepository : IBaseRepository
    {
        Task<Employee> GetById(long id);
        Task<bool> Add(Employee obj);
        Task<bool> Update(Employee obj);
        Task<bool> Delete(long id);
        Task<List<Employee>> GetAll();
    }
}
