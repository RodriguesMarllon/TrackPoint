using Application.Models.Abstracts;
using Application.Models.Response.Projects;
using MediatR;
using System.Diagnostics.CodeAnalysis;

namespace Application.Handlers.Projects.Queries.GetById
{
    [ExcludeFromCodeCoverage]
    public class GetByIdProjectQueryRequest : IRequest<ResponseBase<GetByIdProjectResponseItem>>
    {
        public long Id { get; set; }
    }
}
