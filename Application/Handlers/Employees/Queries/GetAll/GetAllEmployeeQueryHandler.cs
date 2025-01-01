using Application.Models.Abstracts;
using Application.Models.Response.Employee;
using AutoMapper;
using Domain.Entities.Employees;
using Domain.InterfacesRepositories.Employees;
using Infrastructure.CrossCutting.Utils;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Application.Handlers.Employees.Queries.GetAll
{
    public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQueryRequest, ResponseBase<List<GetAllEmployeeResponseItem>>>
    {
        public readonly IEmployeeRepository _employeeRepository;
        public readonly ILogger _logger;
        public readonly IMapper _mapper;

        public GetAllEmployeeQueryHandler(IEmployeeRepository employeeRepository, ILogger<GetAllEmployeeQueryHandler> logger, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase<List<GetAllEmployeeResponseItem>>> Handle(GetAllEmployeeQueryRequest request, CancellationToken cancellationToken)
        {
            List<Employee> data;
            string errorMessage = "Failed to query all data from Employees.";

            try
            {
                data = await _employeeRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{errorMessage} Ex: {ex.Message}");
                throw new ApiException(errorMessage, HttpStatusCode.InternalServerError);
            }

            if (data == null)
            {
                throw new ApiException("All Employees data not found.", HttpStatusCode.NotFound);
            }

            List<GetAllEmployeeResponseItem> responseItems = new();

            data.ToList().ForEach(data =>
            {
                responseItems.Add(_mapper.Map<GetAllEmployeeResponseItem>(data));
            });

            ResponseBase<List<GetAllEmployeeResponseItem>> response = new(responseItems)
            {
                IsSuccessful = true,
                Message = null,
                StatusCode = StatusCodes.Status200OK
            };

            return response;

        }
    }
}
