using Core;
using Core.Intefraces;
using DataAccess;
using DataAccess.Intefaces;
using Migrations;
using Newtonsoft.Json.Converters;
using Repository;
using Repository.Interfaces;
using Service;
using Service.Interfaces;

const string corsPolicy = "CorsPolicy";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.Converters.Add(new StringEnumConverter());
});;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddPolicy(corsPolicy, corsPolicyBuilder =>
{
    corsPolicyBuilder.WithOrigins("*")
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

builder.Services.AddSingleton<ISettings, Settings>();
builder.Services.AddSingleton<ILogger, CustomLogger>();
builder.Services.AddSingleton<IPostgresContext, PostgresContext>();

//  repos
builder.Services.AddTransient<IUserRepository, UserRepository>();

//  services
builder.Services.AddTransient<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(corsPolicy);

app.UseHttpsRedirection();

app.MapControllers();

new Migrator(app.Services.GetRequiredService<ISettings>(), app.Services.GetRequiredService<ILogger>()).Migrate();

app.Run();