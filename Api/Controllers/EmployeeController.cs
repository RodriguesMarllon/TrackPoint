using Api.Models.Employee.Querie;
using Api.Models.Employee.RequestBody;
using Application.Handlers.Clients.RequestBody.Update;
using Application.Handlers.Employees.Queries.Delete;
using Application.Handlers.Employees.Queries.GetAll;
using Application.Handlers.Employees.RequestBody.Create;
using Application.Handlers.Employees.RequestBody.Update;
using AutoMapper;
using DocumentFormat.OpenXml.Wordprocessing;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace Api.Controllers
{
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : BaseController
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMapper _mapper;

        public EmployeeController(ILogger<EmployeeController> logger, IMediator mediator, IMapper mapper) : base(mediator)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeBodyModel body)
        {
            try
            {
                var queryMediator = _mapper.Map<CreateEmployeeBodyRequest>(body);
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
            GetAllEmployeeQueryRequest queryMediator = new();
            return Ok(await _mediator.Send(queryMediator));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeBodyModel body)
        {
            var queryMediator = _mapper.Map<UpdateEmployeeBodyRequest>(body);
            return Ok(await _mediator.Send(queryMediator));
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteEmployeeQueryModel query)
        {
            var queryMediator = _mapper.Map<DeleteEmployeeQueryRequest>(query);
            return Ok(await _mediator.Send(queryMediator));
        }
    }
}
