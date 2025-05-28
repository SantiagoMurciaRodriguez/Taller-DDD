using Booking.Domain.Interfaces;
using Booking.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IReservaRepository, ReservaRepository>();
builder.Services.AddSingleton<IRutaRepository, RutaRepository>();
builder.Services.AddSingleton<IPasajeroRepository, PasajeroRepository>();
builder.Services.AddSingleton<IPagoRepository, PagoRepository>();
builder.Services.AddSingleton<INotificacionRepository, NotificacionRepository>();

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
