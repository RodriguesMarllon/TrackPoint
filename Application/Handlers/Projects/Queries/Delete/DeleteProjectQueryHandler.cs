using Application.Models.Abstracts;
using Application.Models.Response.Projects;
using AutoMapper;
using Domain.InterfacesRepositories.Projects;
using Infrastructure.CrossCutting.Utils;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Application.Handlers.Projects.Queries.Delete
{
    public class DeleteProjectQueryHandler : IRequestHandler<DeleteProjectQueryRequest, ResponseBase<DeleteProjectResponseItem>>
    {
        public readonly IProjectRepository _projectRepository;
        public readonly ILogger _logger;
        public readonly IMapper _mapper;

        public DeleteProjectQueryHandler(IProjectRepository projectRepository, ILogger<DeleteProjectQueryHandler> logger, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase<DeleteProjectResponseItem>> Handle(DeleteProjectQueryRequest request, CancellationToken cancellationToken)
        {
            string errorMessage = "Failed to delete a Project.";

            try
            {
                await _projectRepository.Delete(request.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{errorMessage} Ex: {ex.Message}");
                throw new ApiException(errorMessage, HttpStatusCode.InternalServerError);
            }

            ResponseBase<DeleteProjectResponseItem> response = new(null)
            {
                IsSuccessful = true,
                Message = null,
                StatusCode = StatusCodes.Status200OK
            };

            return response;
        }
    }
}
