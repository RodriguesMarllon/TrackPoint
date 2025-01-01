using Application.Models.Abstracts;
using Application.Models.Response.Projects;
using AutoMapper;
using Domain.Entities.Projects;
using Domain.InterfacesRepositories.Projects;
using Infrastructure.CrossCutting.Utils;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Application.Handlers.Projects.Queries.GetById
{
    public class GetByIdProjectQueryHandler : IRequestHandler<GetByIdProjectQueryRequest, ResponseBase<GetByIdProjectResponseItem>>
    {
        public readonly IProjectRepository _projectRepository;
        public readonly ILogger _logger;
        public readonly IMapper _mapper;

        public GetByIdProjectQueryHandler(IProjectRepository projectRepository, ILogger<GetByIdProjectQueryHandler> logger, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase<GetByIdProjectResponseItem>> Handle(GetByIdProjectQueryRequest request, CancellationToken cancellationToken)
        {
            Project data;
            string errorMessage = "Failed to query data by id from Project.";

            try
            {
                data = await _projectRepository.GetById(request.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{errorMessage} Ex: {ex.Message}");
                throw new ApiException(errorMessage, HttpStatusCode.InternalServerError);
            }

            if (data == null)
            {
                throw new ApiException($"Project by id Data not found.", HttpStatusCode.NotFound);
            }

            var responseItems = _mapper.Map<GetByIdProjectResponseItem>(data);

            ResponseBase<GetByIdProjectResponseItem> response = new(responseItems)
            {
                IsSuccessful = true,
                Message = null,
                StatusCode = StatusCodes.Status200OK
            };

            return response;
        }
    }
}
