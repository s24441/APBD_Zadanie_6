using APBD_Zadanie_6.Abstracts;
using APBD_Zadanie_6.Models;
using APBD_Zadanie_6.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services
    .AddDbContext<PharmacyContext>(options => {
        options.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
    })
    .AddScoped<IPrescriptionRepository, PrescriptionRepository>()
    .AddScoped<IPatientRepository, PatientRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
