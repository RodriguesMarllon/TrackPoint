using Application.Models.Abstracts;
using Application.Models.Response.Activities;
using AutoMapper;
using Domain.Entities.Activities;
using Domain.InterfacesRepositories.Activities;
using Infrastructure.CrossCutting.Utils;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Application.Handlers.Activities.RequestBody.Create
{
    public class CreateActivityBodyHandler : IRequestHandler<CreateActivityBodyRequest, ResponseBase<CreateActivityResponseItem>>
    {
        public readonly IActivityRepository _activityRepository;
        public readonly ILogger _logger;
        public readonly IMapper _mapper;

        public CreateActivityBodyHandler(IActivityRepository activityRepository, ILogger<CreateActivityBodyHandler> logger, IMapper mapper)
        {
            _activityRepository = activityRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase<CreateActivityResponseItem>> Handle(CreateActivityBodyRequest request, CancellationToken cancellationToken)
        {
            var errorMessage = "Failed to create Activity.";

            try
            {
                await _activityRepository.Add(_mapper.Map<Activity>(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(errorMessage, ex.Message);
                throw new ApiException(errorMessage, HttpStatusCode.InternalServerError);
            }

            ResponseBase<CreateActivityResponseItem> response = new(null)
            {
                IsSuccessful = true,
                Message = null,
                StatusCode = StatusCodes.Status200OK
            };

            return response;
        }
    }
}
