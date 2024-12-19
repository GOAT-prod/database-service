using Core;
using Core.Intefraces;
using DataAccess;
using DataAccess.Intefaces;
using Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ISettings, Settings>();
builder.Services.AddSingleton<ILogger, CustomLogger>();
builder.Services.AddSingleton<IPostgresContext, PostgresContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

new Migrator(app.Services.GetRequiredService<ISettings>(), app.Services.GetRequiredService<ILogger>()).Migrate();

app.Run();
