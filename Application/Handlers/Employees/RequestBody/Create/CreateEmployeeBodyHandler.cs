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

namespace Application.Handlers.Employees.RequestBody.Create
{
    public class CreateEmployeeBodyHandler : IRequestHandler<CreateEmployeeBodyRequest, ResponseBase<CreateEmployeeResponseItem>>
    {
        public readonly IEmployeeRepository _employeeRepository;
        public readonly ILogger _logger;
        public readonly IMapper _mapper;

        public CreateEmployeeBodyHandler(IEmployeeRepository employeeRepository, ILogger<CreateEmployeeBodyHandler> looger, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _logger = looger;
            _mapper = mapper;
        }

        public async Task<ResponseBase<CreateEmployeeResponseItem>> Handle(CreateEmployeeBodyRequest request, CancellationToken cancellationToken)
        {
            string messageError = $"Failed to create data from Employee.";
            try
            {
                request.DateInsertUpdate = DateTime.Now;
                await _employeeRepository.Add(_mapper.Map<Employee>(request));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{messageError} Ex: {ex.Message}");
                throw new ApiException(messageError, HttpStatusCode.InternalServerError);
            }

            ResponseBase<CreateEmployeeResponseItem> response = new(null)
            {
                IsSuccessful = true,
                Message = null,
                StatusCode = StatusCodes.Status200OK
            };

            return response;
        }
    }
}
