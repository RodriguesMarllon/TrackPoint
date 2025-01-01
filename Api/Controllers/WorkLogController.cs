using Api.Models.WorkLog.Queries.Delete;
using Api.Models.WorkLog.RequestBody;
using Application.Handlers.WorkLogs.Queries.Delete;
using Application.Handlers.WorkLogs.Queries.GetAll;
using Application.Handlers.WorkLogs.RequestBody.Create;
using Application.Handlers.WorkLogs.RequestBody.Update;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace Api.Controllers
{
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Route("[controller]")]
    public class WorkLogController : BaseController
    {
        private readonly ILogger<WorkLogController> _logger;
        private readonly IMapper _mapper;

        public WorkLogController(ILogger<WorkLogController> logger, IMediator mediator, IMapper mapper) : base(mediator)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateWorkLogBodyModel body)
        {
            try
            {
                var queryMediator = _mapper.Map<CreateWorkLogBodyRequest>(body);
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
            GetAllWorkLogQueryRequest queryMediator = new();
            return Ok(await _mediator.Send(queryMediator));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateWorkLogBodyModel body)
        {
            var queryMediator = _mapper.Map<UpdateWorkLogBodyRequest>(body);
            return Ok(await _mediator.Send(queryMediator));
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteWorkLogQueryModel query)
        {
            var queryMediator = _mapper.Map<DeleteWorkLogQueryRequest>(query);
            return Ok(await _mediator.Send(queryMediator));
        }
    }
}
