using Microsoft.EntityFrameworkCore;
using Register.Domain;
using Register.Infrastructure;
using Register.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Context");

/*builder.Services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>(); */

builder.Services.AddContext<Context>(options => options.UseNpgsql(connectionString));
builder.Services.AddClassesMatchingInterfaces(nameof(Register));
builder.Services.AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
