using Api.Models.Client.Queries;
using Api.Models.Client.RequestBody;
using Application.Handlers.Clients.Queries.Delete;
using Application.Handlers.Clients.Queries.GetAll;
using Application.Handlers.Clients.RequestBody.Create;
using Application.Handlers.Clients.RequestBody.Update;
using Application.Handlers.Projects.Queries.Delete;
using Application.Handlers.Projects.RequestBody.Update;
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

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            GetAllClientQueryRequest queryMediator = new();
            return Ok(await _mediator.Send(queryMediator));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateClientBodyModel body)
        {
            var queryMediator = _mapper.Map<UpdateClientBodyRequest>(body);
            return Ok(await _mediator.Send(queryMediator));
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteClientQueryModel query)
        {
            var queryMediator = _mapper.Map<DeleteClientQueryRequest>(query);
            return Ok(await _mediator.Send(queryMediator));
        }
    }
}
