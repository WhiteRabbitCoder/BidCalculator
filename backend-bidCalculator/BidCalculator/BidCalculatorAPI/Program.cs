using System;
using System.IO;
using System.Reflection;
using Microsoft.OpenApi.Models;
using BidCalculatorAPI.Middlewares;
using FluentValidation.AspNetCore;
using BidCalculatorAPI.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<VehicleValidator>());

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Bid Calculator API",
        Version = "v1",
        Description = "API for calculating vehicle bid fees."
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();
app.MapControllers();
app.Run();