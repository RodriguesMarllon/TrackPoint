using Application.Models.Abstracts;
using Application.Models.Response.Projects;
using MediatR;

namespace Application.Handlers.Projects.Queries.Delete
{
    public class DeleteProjectQueryRequest : IRequest<ResponseBase<DeleteProjectResponseItem>>
    {
        public long Id { get; set; }
    }
}
