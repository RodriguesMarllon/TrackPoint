using Application.Models.Abstracts;
using Application.Models.Response.Employee;
using FluentValidation;
using MediatR;

namespace Application.Handlers.Employees.Queries.Delete
{
    public class DeleteEmployeeQueryRequest : IRequest<ResponseBase<DeleteEmployeeResponseItem>>
    {
        public long Id { get; set; }
    }
}
