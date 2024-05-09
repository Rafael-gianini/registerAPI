using MediatR;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using registerAPI.Commands.Person;
using registerAPI.Entity;
using registerAPI.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ConnectionMongo>
    (builder.Configuration.GetSection("connectionSettings"));



builder.Services.AddScoped<DeliveryPersonService>();
builder.Services.AddScoped<BikeService>();
builder.Services.AddScoped<RentedService>();
builder.Services.AddScoped<InformationRentedMotorcycleService>();



builder.Services.AddMediatR(Assembly.GetExecutingAssembly());


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseRouting();
    app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
   
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
