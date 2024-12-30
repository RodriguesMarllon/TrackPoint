using Api.Models.Client.RequestBody;
using Api.Models.Project.Queries;
using Api.Models.Project.RequestBody;
using Application.Handlers.Clients.RequestBody.Create;
using Application.Handlers.Projects.Queries.GetById;
using Application.Handlers.Projects.RequestBody.Create;
using Application.Handlers.Projects.RequestBody.Update;
using Application.Models.Response;
using Application.Models.Response.Clients;
using AutoMapper;
using Domain.Entities.Clients;
using Domain.Entities.Projects;

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

            CreateMap<CreateClientBodyRequest, Client>();
            CreateMap<CreateClientBodyModel, CreateClientBodyRequest>();
        }
    }
}
