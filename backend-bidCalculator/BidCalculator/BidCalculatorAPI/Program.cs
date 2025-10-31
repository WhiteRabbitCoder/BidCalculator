using System;
using System.IO;
using System.Reflection;
using Microsoft.OpenApi.Models;
using BidCalculatorAPI.Middlewares;
using BidCalculatorAPI.Services;
using BidCalculatorAPI.Services.FeeCalculators;
using BidCalculatorAPI.Services.Interfaces;
using BidCalculatorAPI.Validators;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<VehicleValidator>());

builder.Services.AddScoped<BuyerFeeCalculator>();
builder.Services.AddScoped<SpecialFeeCalculator>();
builder.Services.AddScoped<AssociationFeeCalculator>();
builder.Services.AddScoped<StorageFeeCalculator>();

builder.Services.AddScoped<IFeeCalculator, BuyerFeeCalculator>();
builder.Services.AddScoped<IFeeCalculator, SpecialFeeCalculator>();
builder.Services.AddScoped<IFeeCalculator, AssociationFeeCalculator>();
builder.Services.AddScoped<IFeeCalculator, StorageFeeCalculator>();

builder.Services.AddScoped<TotalFeeService>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors();

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

app.UseCors(policy => policy
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseRouting();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();

app.Run();
