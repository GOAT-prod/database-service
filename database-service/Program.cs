using Core;
using Core.Intefraces;
using DataAccess;
using DataAccess.Intefaces;
using Migrations;

const string CORS_POLICY = "CorsPolicy";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddPolicy(CORS_POLICY, builder =>
{
    builder.WithOrigins("*")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
}));

builder.Services.AddSingleton<ISettings, Settings>();
builder.Services.AddSingleton<ILogger, CustomLogger>();
builder.Services.AddSingleton<IPostgresContext, PostgresContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(CORS_POLICY);

app.UseHttpsRedirection();

app.MapControllers();

new Migrator(app.Services.GetRequiredService<ISettings>(), app.Services.GetRequiredService<ILogger>()).Migrate();

app.Run();