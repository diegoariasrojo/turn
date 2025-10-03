using Microsoft.EntityFrameworkCore;
using TurnosConsultorioMedico.Models;
using TurnosConsultorioMedico.Repositories.Implementations;
using TurnosConsultorioMedico.Repositories.Interfaces;
using TurnosConsultorioMedico.Services.Implementations;
using TurnosConsultorioMedico.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Agregamos DbContext con la cadena de conexi�n
builder.Services.AddDbContext<TurnosContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Hacemos inyecci�n de dependencias en repositories y services
builder.Services.AddScoped<IMedicoRepository, MedicoRepository>();
builder.Services.AddScoped<IMedicoService, MedicoService>();
builder.Services.AddScoped<ITurnoRepository, TurnoRepository>();
builder.Services.AddScoped<ITurnoService, TurnoService>();

builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
