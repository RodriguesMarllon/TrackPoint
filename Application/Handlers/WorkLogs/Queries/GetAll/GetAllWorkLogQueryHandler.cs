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

namespace Application.Handlers.WorkLogs.Queries.GetAll
{
    public class GetAllWorkLogQueryHandler : IRequestHandler<GetAllWorkLogQueryRequest, ResponseBase<List<GetAllWorkLogResponseItem>>>
    {
        public readonly IWorkLogRepository _workLogRepository;
        public readonly ILogger _logger;
        public readonly IMapper _mapper;

        public GetAllWorkLogQueryHandler(IWorkLogRepository workLogRepository, ILogger<GetAllWorkLogQueryHandler> logger, IMapper mapper)
        {
            _workLogRepository = workLogRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase<List<GetAllWorkLogResponseItem>>> Handle(GetAllWorkLogQueryRequest request, CancellationToken cancellationToken)
        {
            List<WorkLog> data;
            var errorMessage = "Failed to query All WorkLog data";

            try
            {
                data = await _workLogRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(errorMessage, ex.Message);
                throw new ApiException(errorMessage, HttpStatusCode.InternalServerError);
            }

            if (data == null)
            {
                throw new ApiException("All WorkLog data not found.", HttpStatusCode.NotFound);
            }

            List<GetAllWorkLogResponseItem> responseItems = new();

            data.ToList().ForEach(data =>
            {
                responseItems.Add(_mapper.Map<GetAllWorkLogResponseItem>(data));
            });

            ResponseBase<List<GetAllWorkLogResponseItem>> response = new(responseItems)
            {
                IsSuccessful = true,
                Message = null,
                StatusCode = StatusCodes.Status200OK
            };

            return response;
        }
    }
}
