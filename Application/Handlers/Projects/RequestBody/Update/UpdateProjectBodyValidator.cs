using Application.Models.Response.Projects;
using FluentValidation;

namespace Application.Handlers.Projects.RequestBody.Update
{
    public class UpdateProjectBodyValidator : AbstractValidator<UpdateProjectResponseItem>
    {
        public UpdateProjectBodyValidator() 
        {
        }
    }
}
