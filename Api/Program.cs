using Api.Filters;
using Api.Middleware;
using Application.Common;
using Domain.Configuration;
using Domain.Interfaces.Requests;
using Domain.Service;
using Infraestructure.Configuration;
using Infrastructure.Common;
using Infrastructure.Services.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Polly;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.WebHost.ConfigureKestrel(options =>
    {
        options.Limits.MaxRequestBodySize = 2147483647;
    });
}

builder.Services.AddDbContext<TrackPointContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("TrackPointConnetion"), op => op.CommandTimeout(600)));

builder.Services.AddControllers(options =>
{
    options.Filters.Add<LogActionFilter>();
})
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
})
.AddControllersAsServices();

builder.Services.AddHttpContextAccessor();

builder.Services.Configure<ApiSettings>(builder.Configuration);

builder.Services.AddHttpClient<IExternalApiService, ExternalApiService>()
    .AddTransientHttpErrorPolicy(policy =>
        policy.WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))));

builder.Services.AddApplication();
builder.Services.AddServices();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder => builder
            .WithOrigins("http://localhost:5175")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Data API", Version = "v1" });
    c.OperationFilter<RemoveUnusedParametersFilter>();
    c.SchemaFilter<EnumSchemaFilter>();
});

var app = builder.Build();

ServiceProviderHelper.ServiceProvider = app.Services;

// Use CORS
app.UseCors("AllowReactApp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(config =>
    {
        config.ConfigObject.AdditionalItems["syntaxHighlight"] = new Dictionary<string, object>
        {
            ["activated"] = false
        };
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseExceptionMiddleware();

app.Run();

public class RemoveUnusedParametersFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters != null)
        {
            operation.Parameters = operation.Parameters
                .Where(p => p.Name != "ContentType" && p.Name != "ContentDisposition" && p.Name != "Headers")
                .ToList();
        }
    }
}

public class EnumSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type.IsEnum)
        {
            var enumNames = Enum.GetNames(context.Type);
            var enumValues = Enum.GetValues(context.Type);

            schema.Enum.Clear();
            foreach (var enumValue in enumValues)
            {
                // Add enum description if it exists
                var enumName = enumNames[Array.IndexOf(enumValues, enumValue)];
                var description = enumValue.ToString();

                // Add the value along with description
                schema.Enum.Add(new OpenApiString(description));
            }
        }
    }
}
