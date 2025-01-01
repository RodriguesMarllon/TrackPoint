using Application.Models.Abstracts;
using Application.Models.Response.Employee;
using MediatR;
using System.Diagnostics.CodeAnalysis;

namespace Application.Handlers.Employees.Queries.GetAll
{
    [ExcludeFromCodeCoverage]
    public class GetAllEmployeeQueryRequest : IRequest<ResponseBase<List<GetAllEmployeeResponseItem>>>
    {
    }
}
