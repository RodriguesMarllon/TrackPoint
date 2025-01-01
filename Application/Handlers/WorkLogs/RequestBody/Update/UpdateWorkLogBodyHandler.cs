using Application.Models.Abstracts;
using Application.Models.Response.WorkLog;
using AutoMapper;
using Domain.Entities.WorkLogs;
using Domain.InterfacesRepositories.WorkLogs;
using Infrastructure.CrossCutting.Utils;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Application.Handlers.WorkLogs.RequestBody.Update
{
    public class UpdateWorkLogBodyHandler : IRequestHandler<UpdateWorkLogBodyRequest, ResponseBase<UpdateWorkLogResponseItem>>
    {
        public readonly IWorkLogRepository _workLogRepository;
        public readonly ILogger _logger;
        public readonly IMapper _mapper;

        public UpdateWorkLogBodyHandler(IWorkLogRepository workLogRepository, ILogger<UpdateWorkLogBodyHandler> logger, IMapper mapper)
        {
            _workLogRepository = workLogRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase<UpdateWorkLogResponseItem>> Handle(UpdateWorkLogBodyRequest request, CancellationToken cancellationToken)
        {
            var errorMessage = "Failed on update the WorkLog data.";

            try
            {
                await _workLogRepository.Update(_mapper.Map<WorkLog>(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(errorMessage, ex.Message);
                throw new ApiException(errorMessage, HttpStatusCode.InternalServerError);
            }

            ResponseBase<UpdateWorkLogResponseItem> response = new(null)
            {
                IsSuccessful = true,
                Message = null, 
                StatusCode = StatusCodes.Status200OK
            };

            return response;
        }
    }
}
