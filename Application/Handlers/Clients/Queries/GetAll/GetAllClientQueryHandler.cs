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

namespace Application.Handlers.Clients.Queries.GetAll
{
    public class GetAllClientQueryHandler : IRequestHandler<GetAllClientQueryRequest, ResponseBase<List<GetAllClientResponseItem>>>
    {
        public readonly IClientRepository _clientRepository;
        public readonly ILogger _logger;
        public readonly IMapper _mapper;

        public GetAllClientQueryHandler(IClientRepository clientRepository, ILogger<GetAllClientQueryHandler> logger, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase<List<GetAllClientResponseItem>>> Handle(GetAllClientQueryRequest request, CancellationToken cancellationToken)
        {
            List<Client> data;
            string errorMessage = "Failed to query all data from Client.";

            try
            {
                data = await _clientRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{errorMessage} Ex: {ex.Message}");
                throw new ApiException(errorMessage, HttpStatusCode.InternalServerError);
            }

            if (data == null)
            {
                throw new ApiException("All Client data not found.", HttpStatusCode.NotFound);
            }

            List<GetAllClientResponseItem> responseItems = new();

            data.ToList().ForEach(data =>
            {
                responseItems.Add(_mapper.Map<GetAllClientResponseItem>(data));
            });

            ResponseBase<List<GetAllClientResponseItem>> response = new(responseItems)
            {
                IsSuccessful = true,
                Message = null,
                StatusCode = StatusCodes.Status200OK
            };

            return response;

        }
    }
}
