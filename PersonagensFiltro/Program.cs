using Microsoft.EntityFrameworkCore;
using PersonagensFiltro.DTO;
using PersonagensFiltro.SERVICES;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IServiceP, ServicesPersonagem>();


builder.Services.AddDbContext<DataFile>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("stringConnection"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("stringConnection"))));
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
