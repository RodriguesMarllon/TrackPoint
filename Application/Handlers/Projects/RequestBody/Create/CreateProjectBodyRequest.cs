using Application.Models.Abstracts;
using Application.Models.Response.Projects;
using MediatR;

namespace Application.Handlers.Projects.RequestBody.Create
{
    public class CreateProjectBodyRequest : IRequest<ResponseBase<CreateProjectResponseItem>>
    {
        public string Name { get; set; }
        public decimal TotalHours { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
