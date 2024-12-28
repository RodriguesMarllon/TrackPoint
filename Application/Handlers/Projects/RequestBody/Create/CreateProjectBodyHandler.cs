using Application.Models.Abstracts;
using Application.Models.Response;
using AutoMapper;
using Domain.Entities.Projects;
using Domain.InterfacesRepositories.Projects;
using Infrastructure.CrossCutting.Utils;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Application.Handlers.Projects.RequestBody.Create
{
    public class CreateProjectBodyHandler : IRequestHandler<CreateProjectBodyRequest, ResponseBase<CreateProjectResponseItem>>
    {
        public readonly IProjectRepository _projectRepository;
        public readonly ILogger _logger;
        public readonly IMapper _mapper;

        public CreateProjectBodyHandler(IProjectRepository projectRepository, ILogger<CreateProjectBodyHandler> logger, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase<CreateProjectResponseItem>> Handle(CreateProjectBodyRequest request, CancellationToken cancellationToken)
        {
            string messageError = $"Failed to create data from Project.";

            try
            {
                await _projectRepository.Add(_mapper.Map<Project>(request));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{messageError} Ex: {ex.Message}");
                throw new ApiException(messageError, HttpStatusCode.InternalServerError);
            }

            ResponseBase<CreateProjectResponseItem> response = new(null)
            {
                IsSuccessful = true,
                Message = null,
                StatusCode = StatusCodes.Status200OK
            };

            return response;
        }
    }
}
