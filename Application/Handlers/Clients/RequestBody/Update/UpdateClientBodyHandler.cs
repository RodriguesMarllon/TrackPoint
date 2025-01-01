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

namespace Application.Handlers.Clients.RequestBody.Update
{
    public class UpdateClientBodyHandler : IRequestHandler<UpdateClientBodyRequest, ResponseBase<UpdateClientResponseItem>>
    {
        public readonly IClientRepository _clientRepository;
        public readonly ILogger _logger;
        public readonly IMapper _mapper;

        public UpdateClientBodyHandler(IClientRepository clientRepository, ILogger<UpdateClientBodyHandler> logger, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase<UpdateClientResponseItem>> Handle(UpdateClientBodyRequest request, CancellationToken cancellationToken)
        {
            string messageError = $"Failed on update the Client data.";

            try
            {
                await _clientRepository.Update(_mapper.Map<Client>(request));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{messageError}. ex: " + ex.Message);
                throw new ApiException(messageError, HttpStatusCode.InternalServerError);
            }
            ResponseBase<UpdateClientResponseItem> response = new(null)
            {
                IsSuccessful = true,
                Message = null,
                StatusCode = StatusCodes.Status200OK
            };

            return response;
        }
    }
}
