﻿using Api.Models.Project.Queries;
using Api.Models.Project.RequestBody;
using Application.Handlers.Projects.Queries.Delete;
using Application.Handlers.Projects.Queries.GetAll;
using Application.Handlers.Projects.Queries.GetById;
using Application.Handlers.Projects.RequestBody.Create;
using Application.Handlers.Projects.RequestBody.Update;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ExcludeFromDescription]
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ProjectController> _logger;

        public ProjectController(
            ILogger<ProjectController> logger, 
            IMediator mediator, IMapper mapper
            ): base(mediator)
        {
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateProjectBodyModel body)
        {
            try
            {
                var queryMediator = _mapper.Map<CreateProjectBodyRequest>(body);
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
            GetAllProjectQueryRequest queryMediator = new();
            return Ok(await _mediator.Send(queryMediator));
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdProjectQueryModel query)
        {
            var queryMediator = _mapper.Map<GetByIdProjectQueryRequest>(query);
            return Ok(await _mediator.Send(queryMediator));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateProjectBodyModel body)
        {
            var queryMediator = _mapper.Map<UpdateProjectBodyRequest>(body);
            return Ok(await _mediator.Send(queryMediator));
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteProjectQueryModel query)
        {
            var queryMediator = _mapper.Map<DeleteProjectQueryRequest>(query);
            return Ok(await _mediator.Send(queryMediator));
        }


        //[HttpPost("create")]
        //public async Task<IActionResult> Create([FromBody] CreateProjectBodyModel body)
        //{
        //    var queryMediator = _mapper.Map<CreateProjectBodyRequest>(body);
        //    return Ok(await _mediator.Send(queryMediator));
        //}
    }
}
