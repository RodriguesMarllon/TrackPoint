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

namespace Application.Handlers.WorkLogs.RequestBody.Create
{
    public class CreateWorkLogBodyHandler : IRequestHandler<CreateWorkLogBodyRequest, ResponseBase<CreateWorkLogResponseItem>>
    {
        public readonly IWorkLogRepository _workLogRespository;
        public readonly ILogger _logger;
        public readonly IMapper _mapper;

        public CreateWorkLogBodyHandler(IWorkLogRepository workLogRespository, ILogger<CreateWorkLogBodyHandler> logger, IMapper mapper)
        {
            _workLogRespository = workLogRespository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase<CreateWorkLogResponseItem>> Handle(CreateWorkLogBodyRequest request, CancellationToken cancellationToken)
        {
            var messageError = "Failed to create data from WorkLog.";
            try
            {
                await _workLogRespository.Add(_mapper.Map<WorkLog>(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(messageError, ex.Message);
                throw new ApiException(messageError, HttpStatusCode.InternalServerError);
            }

            ResponseBase<CreateWorkLogResponseItem> response = new(null)
            {
                IsSuccessful = true,
                Message = null,
                StatusCode = StatusCodes.Status200OK
            };

            return response;
        }
    }
}
