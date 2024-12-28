using Application.Models.Abstracts;
using Application.Models.Response;
using MediatR;
using System.Diagnostics.CodeAnalysis;

namespace Application.Handlers.Projects.Queries.GetAll
{
    [ExcludeFromCodeCoverage]
    public class GetAllProjectQueryRequest : IRequest<ResponseBase<List<GetAllProjectResponseItem>>>
    {
    }
}
