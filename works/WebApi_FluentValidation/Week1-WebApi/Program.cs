using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(
    opt =>
    {
        opt.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ApiBehaviorOptions>(config => config.SuppressModelStateInvalidFilter = true);

builder.Services
    .AddFluentValidationAutoValidation(opt => opt.DisableDataAnnotationsValidation = true)
    .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
//builder.Services.AddScoped<IValidator<Student>, StudentValidator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
