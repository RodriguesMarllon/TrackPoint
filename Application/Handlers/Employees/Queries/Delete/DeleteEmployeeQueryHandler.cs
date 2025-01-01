using Application.Models.Abstracts;
using Application.Models.Response.Employee;
using AutoMapper;
using Domain.InterfacesRepositories.Employees;
using Infrastructure.CrossCutting.Utils;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Application.Handlers.Employees.Queries.Delete
{
    public class DeleteEmployeeQueryHandler : IRequestHandler<DeleteEmployeeQueryRequest, ResponseBase<DeleteEmployeeResponseItem>>
    {
        public readonly IEmployeeRepository _employeeRespository;
        public readonly ILogger _logger;
        public readonly IMapper _mapper;

        public DeleteEmployeeQueryHandler(IEmployeeRepository employeeRespository, ILogger<DeleteEmployeeQueryHandler> logger, IMapper mapper)
        {
            _employeeRespository = employeeRespository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase<DeleteEmployeeResponseItem>> Handle(DeleteEmployeeQueryRequest request, CancellationToken cancellationToken)
        {
            string errorMessage = "Failed to delete a Employee.";

            try
            {
                await _employeeRespository.Delete(request.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{errorMessage} Ex: {ex.Message}");
                throw new ApiException(errorMessage, HttpStatusCode.InternalServerError);
            }

            ResponseBase<DeleteEmployeeResponseItem> response = new(null)
            {
                IsSuccessful = true,
                Message = null,
                StatusCode = StatusCodes.Status200OK
            };

            return response;
        }
    }
}
