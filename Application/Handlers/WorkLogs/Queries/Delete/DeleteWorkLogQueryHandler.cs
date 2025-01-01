using Application.Models.Abstracts;
using Application.Models.Response.WorkLog;
using AutoMapper;
using Domain.InterfacesRepositories.WorkLogs;
using Infrastructure.CrossCutting.Utils;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Application.Handlers.WorkLogs.Queries.Delete
{
    public class DeleteWorkLogQueryHandler : IRequestHandler<DeleteWorkLogQueryRequest, ResponseBase<DeleteWorkLogResponseItem>>
    {
        public readonly IWorkLogRepository _workLogRepository;
        public readonly ILogger _logger;
        public readonly IMapper _mapper;

        public DeleteWorkLogQueryHandler(IWorkLogRepository workLogRepository, ILogger<DeleteWorkLogQueryHandler> logger, IMapper mapper)
        {
            _workLogRepository = workLogRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase<DeleteWorkLogResponseItem>> Handle(DeleteWorkLogQueryRequest request, CancellationToken cancellationToken)
        {
            var errorMessage = "Failed to Delete a WorkLog.";

            try
            {
                await _workLogRepository.Delete(request.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(errorMessage, ex.Message);
                throw new ApiException(errorMessage, HttpStatusCode.InternalServerError);
            }

            ResponseBase<DeleteWorkLogResponseItem> response = new(null)
            {
                IsSuccessful = true,
                Message = null,
                StatusCode = StatusCodes.Status200OK
            };

            return response;
        }
    }
}
