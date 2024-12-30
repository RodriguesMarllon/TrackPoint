using Api.Models.Client.RequestBody;
using Application.Handlers.Clients.RequestBody.Create;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace Api.Controllers
{
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Route("[controller]")]
    public class ClientController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ClientController> _logger;

        public ClientController(
            ILogger<ClientController> logger,
            IMediator mediator, IMapper mapper
            ) : base(mediator)
        {
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateClientBodyModel body)
        {
            try
            {
                var queryMediator = _mapper.Map<CreateClientBodyRequest>(body);
                var result = await _mediator.Send(queryMediator);
                return Ok(result);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError($"Mapping error: {ex.Message}");
                return BadRequest("Mapping error");
            }
        }
    }
}
