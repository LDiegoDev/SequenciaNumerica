using FluentValidation;
using SequenciaNumerica.Api.Models;
using SequenciaNumerica.Api.Validators;
using SequenciaNumerica.Application.Interfaces;
using SequenciaNumerica.Application.Services;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .Enrich.FromLogContext()
    .CreateLogger();


var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

builder.Services.AddScoped<ISequenciaService, SequenciaService>();
builder.Services.AddScoped<IValidator<SequenciaInput>, SequenciaInputValidator>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
