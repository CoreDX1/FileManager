using FileExploreProject.Data;
using FileExploreProject.Interfaces;
using FileExploreProject.Models;
using FileExploreProject.Services;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Cors
string _Mycors = "Mycors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: _Mycors,
        buider =>
        {
            buider
                .SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
                .AllowAnyHeader()
                .AllowAnyMethod();
        }
    );
});

builder.Services.AddScoped<InterfaceFiles<RotDir>, IMyFiles>();
builder.Services.AddScoped<InterfaceUploadImagen, IUploadImagen>();

builder.Services
    .AddDbContext<DbContextPostgres>(
        opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("PostgresSQLConnection"))
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(_Mycors);
app.UseAuthorization();

app.MapControllers();

app.Run();
