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

namespace Application.Handlers.Projects.RequestBody.Update
{
    public class UpdateProjectBodyHandler : IRequestHandler<UpdateProjectBodyRequest, ResponseBase<UpdateProjectResponseItem>>
    {
        public readonly IProjectRepository _projectRepository;
        public readonly ILogger _logger;
        public readonly IMapper _mapper;

        public UpdateProjectBodyHandler(IProjectRepository projectRepository, ILogger<UpdateProjectBodyHandler> logger, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase<UpdateProjectResponseItem>> Handle(UpdateProjectBodyRequest request, CancellationToken cancellationToken)
        {
            string messageError = $"Failed on update the Project data.";

            try
            {
                request.LastUpdated = DateTime.Now;
                await _projectRepository.Update(_mapper.Map<Project>(request));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{messageError}. ex: " + ex.Message);
                throw new ApiException(messageError, HttpStatusCode.InternalServerError);
            }

            ResponseBase<UpdateProjectResponseItem> response = new(null)
            {
                IsSuccessful = true,
                Message = null,
                StatusCode = StatusCodes.Status200OK
            };

            return response;
        }
    }
}
