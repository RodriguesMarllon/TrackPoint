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

namespace Application.Handlers.Projects.Queries.GetAll
{
    public class GetAllProjectQueryHandler : IRequestHandler<GetAllProjectQueryRequest, ResponseBase<List<GetAllProjectResponseItem>>> 
    {
        public readonly IProjectRepository _projectRepository;
        public readonly ILogger _logger;
        public readonly IMapper _mapper;

        public GetAllProjectQueryHandler(IProjectRepository projectRepository,ILogger<GetAllProjectQueryHandler> logger, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase<List<GetAllProjectResponseItem>>> Handle(GetAllProjectQueryRequest request, CancellationToken cancellationToken)
        {
            List<Project> data;
            string errorMessage = "Failed to query all data from Project.";

            try
            {
                data = await _projectRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{errorMessage} Ex: {ex.Message}");
                throw new ApiException(errorMessage, HttpStatusCode.InternalServerError);
            }

            if (data == null)
            {
                throw new ApiException("All Project data not found.", HttpStatusCode.NotFound);
            }

            List<GetAllProjectResponseItem> responseItems = new();

            data.ToList().ForEach(data =>
            {
                responseItems.Add(_mapper.Map<GetAllProjectResponseItem>(data));
            });

            ResponseBase<List<GetAllProjectResponseItem>> response = new(responseItems)
            {
                IsSuccessful = true,
                Message = null,
                StatusCode = StatusCodes.Status200OK
            };

            return response;
        }
    }
}
