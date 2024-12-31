using Application.Models.Abstracts;
using Application.Models.Response.Employee;
using MediatR;

namespace Application.Handlers.Employees.RequestBody.Create
{
    public class CreateEmployeeBodyRequest : IRequest<ResponseBase<CreateEmployeeResponseItem>>
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Signature { get; set; }
        public bool Active { get; set; }
        public string Position { get; set; }
        public DateTime? DateInsertUpdate { get; set; }
    }
}
