﻿using Api.Models.Project.Queries;
using Api.Models.Project.RequestBody;
using Application.Handlers.Projects.Queries.GetById;
using Application.Handlers.Projects.RequestBody.Create;
using Application.Models.Response;
using AutoMapper;
using Domain.Entities.Projects;

namespace Api.AutoMapper
{
    public class TrackPointProfile : Profile
    {
        public TrackPointProfile() 
        {
            CreateMap<Project, GetAllProjectResponseItem>();
            CreateMap<GetByIdProjectQueryModel, GetByIdProjectQueryRequest>();
            CreateMap<Project, GetByIdProjectResponseItem>();
            CreateMap<CreateProjectBodyRequest, Project>();
            CreateMap<CreateProjectBodyModel, CreateProjectBodyRequest>();
        }
    }
}