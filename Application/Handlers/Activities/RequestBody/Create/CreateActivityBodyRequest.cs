using Application.Models.Abstracts;
using Application.Models.Response.Activities;
using MediatR;

namespace Application.Handlers.Activities.RequestBody.Create
{
    public class CreateActivityBodyRequest : IRequest<ResponseBase<CreateActivityResponseItem>>
    {
        public long ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool External { get; set; }
    }
}
