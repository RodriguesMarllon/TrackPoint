using Application.Models.Abstracts;
using Application.Models.Response;
using MediatR;

namespace Application.Handlers.Projects.RequestBody.Create
{
    public class CreateProjectBodyRequest : IRequest<ResponseBase<CreateProjectResponseItem>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
