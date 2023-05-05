using Microsoft.EntityFrameworkCore;
using VKBackendInternship.DataAccessLayer.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<Context>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DatabaseLocation")));
builder.Services.AddDbContext<Context>(options => 
options.UseNpgsql("Host=nin.h.filess.io;Port=5432;Database=Petdatabase_nutsplaymy;Username=Petdatabase_nutsplaymy;Password=c90b96d82c6b34595aa6003959ad11f6429255bf"));

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
