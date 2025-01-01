using Api.Models.Activity.RequestBody;
using Application.Handlers.Activities.RequestBody.Create;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace Api.Controllers
{
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Route("[controller]")]
    public class ActivityController : BaseController
    {
        private readonly ILogger<ActivityController> _logger;
        private readonly IMapper _mapper;

        public ActivityController(ILogger<ActivityController> logger, IMediator mediator, IMapper mapper) : base(mediator)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateActivityBodyModel body)
        {
            try
            {
                var queryMediator = _mapper.Map<CreateActivityBodyRequest>(body);
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
