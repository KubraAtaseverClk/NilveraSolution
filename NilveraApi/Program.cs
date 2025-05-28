using System.Reflection;
using Nilvera.Application.Repository;
using Nilvera.Persistence.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddSingleton<IRabbitMqConnection>(new RabbitMqConnection());
builder.Services.AddScoped<IMessageProducer, RabbitMqProducer>();
builder.Services.AddScoped<IXmlRepository, XmlRepository>();

var assemblies = Assembly.Load("Nilvera.Application");
var conn = builder.Configuration["CONNECTION_STRING"];
//var conn = builder.Configuration.GetConnectionString("DefaultConnection");
DBUtils.SetConnectionString(conn);

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssemblies(typeof(Program).Assembly, assemblies);
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.Run();