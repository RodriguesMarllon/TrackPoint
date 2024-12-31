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

namespace Application.Handlers.Employees.RequestBody.Update
{
    public class UpdateEmployeeBodyHandler : IRequestHandler<UpdateEmployeeBodyRequest, ResponseBase<UpdateEmployeeResponseItem>>
    {
        public readonly IEmployeeRepository _employeeRepository;
        public readonly ILogger _logger;
        public readonly IMapper _mapper;

        public UpdateEmployeeBodyHandler(IEmployeeRepository employeeRepository, ILogger<UpdateEmployeeBodyHandler> looger, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _logger = looger;
            _mapper = mapper;
        }

        public async Task<ResponseBase<UpdateEmployeeResponseItem>> Handle(UpdateEmployeeBodyRequest request, CancellationToken cancellationToken)
        {
            string messageError = $"Failed on update the Employee data.";

            try
            {
                await _employeeRepository.Update(_mapper.Map<Employee>(request));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{messageError}. ex: " + ex.Message);
                throw new ApiException(messageError, HttpStatusCode.InternalServerError);
            }
            ResponseBase<UpdateEmployeeResponseItem> response = new(null)
            {
                IsSuccessful = true,
                Message = null,
                StatusCode = StatusCodes.Status200OK
            };

            return response;
        }

    }
}
