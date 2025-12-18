using NetCATemplate.Application;
using NetCATemplate.Infrastructure;
using NetCATemplate.WebApi;
using NetCATemplate.WebApi.Api.Extensions;
using NetCATemplate.WebApi.Extensions;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services.ConfigureAppJsonSerializer();

builder.Services.AddSwaggerGenWithAuth();

builder.Services.AddApplication()
                .AddPresentation()
                .AddInfrastructure(builder.Configuration);

builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

var app = builder.Build();

app.MapEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerWithUi();
}

app.UseRequestContextLogging();

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.Run();