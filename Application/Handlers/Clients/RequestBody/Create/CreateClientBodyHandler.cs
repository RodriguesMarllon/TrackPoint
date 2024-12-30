using Application.Models.Abstracts;
using Application.Models.Response.Clients;
using AutoMapper;
using Domain.Entities.Clients;
using Domain.InterfacesRepositories.Clients;
using Infrastructure.CrossCutting.Utils;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Application.Handlers.Clients.RequestBody.Create
{
    public class CreateClientBodyHandler : IRequestHandler<CreateClientBodyRequest, ResponseBase<CreateClientResponseItem>>
    {
        public readonly IClientRepository _clientRepository;
        public readonly ILogger _logger;
        public readonly IMapper _mapper;

        public CreateClientBodyHandler(IClientRepository clientRepository, ILogger<CreateClientBodyHandler> logger, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase<CreateClientResponseItem>> Handle(CreateClientBodyRequest request, CancellationToken cancellationToken)
        {
            string messageError = $"Failed to create data from Client.";

            try
            {
                await _clientRepository.Add(_mapper.Map<Client>(request));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{messageError} Ex: {ex.Message}");
                throw new ApiException(messageError, HttpStatusCode.InternalServerError);
            }

            ResponseBase<CreateClientResponseItem> response = new(null)
            {
                IsSuccessful = true,
                Message = null,
                StatusCode = StatusCodes.Status200OK
            };

            return response;
        }
    }
}
