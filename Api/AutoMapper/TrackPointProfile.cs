using Api.Models.Client.Queries;
using Api.Models.Client.RequestBody;
using Api.Models.Employee.Querie;
using Api.Models.Employee.RequestBody;
using Api.Models.Project.Queries;
using Api.Models.Project.RequestBody;
using Api.Models.WorkLog.Queries.Delete;
using Api.Models.WorkLog.RequestBody;
using Application.Handlers.Clients.Queries.Delete;
using Application.Handlers.Clients.RequestBody.Create;
using Application.Handlers.Clients.RequestBody.Update;
using Application.Handlers.Employees.Queries.Delete;
using Application.Handlers.Employees.RequestBody.Create;
using Application.Handlers.Employees.RequestBody.Update;
using Application.Handlers.Projects.Queries.Delete;
using Application.Handlers.Projects.Queries.GetById;
using Application.Handlers.Projects.RequestBody.Create;
using Application.Handlers.Projects.RequestBody.Update;
using Application.Handlers.WorkLogs.Queries.Delete;
using Application.Handlers.WorkLogs.RequestBody.Create;
using Application.Handlers.WorkLogs.RequestBody.Update;
using Application.Models.Response;
using Application.Models.Response.Clients;
using Application.Models.Response.Employee;
using Application.Models.Response.Projects;
using Application.Models.Response.WorkLog;
using AutoMapper;
using Domain.Entities.Clients;
using Domain.Entities.Employees;
using Domain.Entities.Projects;
using Domain.Entities.WorkLogs;

namespace Api.AutoMapper
{
    public class TrackPointProfile : Profile
    {
        public TrackPointProfile() 
        {
            CreateMap<DeleteProjectQueryModel, DeleteProjectQueryRequest>();
            CreateMap<Project, GetAllProjectResponseItem>();
            CreateMap<GetByIdProjectQueryModel, GetByIdProjectQueryRequest>();
            CreateMap<Project, GetByIdProjectResponseItem>();
            CreateMap<CreateProjectBodyRequest, Project>();
            CreateMap<UpdateProjectBodyRequest, Project>();
            CreateMap<CreateProjectBodyModel, CreateProjectBodyRequest>();
            CreateMap<UpdateProjectBodyModel, UpdateProjectBodyRequest>();

            CreateMap<CreateClientBodyRequest, Client>();
            CreateMap<CreateClientBodyModel, CreateClientBodyRequest>();
            CreateMap<Client, GetAllClientResponseItem>();
            CreateMap<UpdateClientBodyRequest, Client>();   
            CreateMap<UpdateClientBodyModel, UpdateClientBodyRequest>();
            CreateMap<DeleteClientQueryModel, DeleteClientQueryRequest>();

            CreateMap<CreateEmployeeBodyRequest, Employee>();
            CreateMap<CreateEmployeeBodyModel, CreateEmployeeBodyRequest>();
            CreateMap<Employee, GetAllEmployeeResponseItem>();
            CreateMap<UpdateEmployeeBodyRequest, Employee>();
            CreateMap<UpdateEmployeeBodyModel, UpdateEmployeeBodyRequest>();
            CreateMap<DeleteEmployeeQueryModel, DeleteEmployeeQueryRequest>();

            CreateMap<CreateWorkLogBodyRequest, WorkLog>();
            CreateMap<CreateWorkLogBodyModel, CreateWorkLogBodyRequest>();
            CreateMap<WorkLog, GetAllWorkLogResponseItem>();
            CreateMap<UpdateWorkLogBodyRequest, WorkLog>();
            CreateMap<UpdateWorkLogBodyModel, UpdateWorkLogBodyRequest>();
            CreateMap<DeleteWorkLogQueryModel, DeleteWorkLogQueryRequest>();
        }
    }
}
