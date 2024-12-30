using Application.Models.Abstracts;
using Application.Models.Response.Clients;
using AutoMapper;
using Domain.InterfacesRepositories.Clients;
using Infrastructure.CrossCutting.Utils;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Application.Handlers.Clients.Queries.Delete
{
    public class DeleteClientQueryHandler : IRequestHandler<DeleteClientQueryRequest, ResponseBase<DeleteClientResponseItem>>
    {
        public readonly IClientRepository _clientRepository;
        public readonly ILogger _logger;
        public readonly IMapper _mapper;

        public DeleteClientQueryHandler(IClientRepository clientRepository, ILogger<DeleteClientQueryHandler> logger, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase<DeleteClientResponseItem>> Handle(DeleteClientQueryRequest request, CancellationToken cancellationToken)
        {
            string errorMessage = "Failed to delete a Project.";

            try
            {
                await _clientRepository.Delete(request.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{errorMessage} Ex: {ex.Message}");
                throw new ApiException(errorMessage, HttpStatusCode.InternalServerError);
            }

            ResponseBase<DeleteClientResponseItem> response = new(null)
            {
                IsSuccessful = true,
                Message = null,
                StatusCode = StatusCodes.Status200OK
            };

            return response;
        }
    }
}
