using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Nilvera.Application.Repository;
using Nilvera.Application.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

var assemblies = Assembly.Load("Nilvera.Application");
var conn = builder.Configuration.GetConnectionString("DefaultConnection");
DBUtils.SetConnectionString(conn);

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssemblies(typeof(Program).Assembly, assemblies);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.Run();