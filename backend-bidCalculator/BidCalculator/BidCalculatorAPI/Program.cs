using BidCalculatorAPI.Services;
using BidCalculatorAPI.Services.Interfaces;
using BidCalculatorAPI.Services.FeeCalculators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register fee calculators
builder.Services.AddScoped<IFeeCalculator, BuyerFeeCalculator>();
builder.Services.AddScoped<IFeeCalculator, SpecialFeeCalculator>();
builder.Services.AddScoped<IFeeCalculator, AssociationFeeCalculator>();
builder.Services.AddScoped<IFeeCalculator, StorageFeeCalculator>();

// Register the total service
builder.Services.AddScoped<TotalFeeService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();