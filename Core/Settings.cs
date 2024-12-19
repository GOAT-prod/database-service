using Core.Intefraces;
using Microsoft.Extensions.Configuration;

namespace Core;

public class Settings : ISettings
{
    private readonly IConfiguration configuration;

    public Settings(IConfiguration configuration)
    {
        var configBuilder = new ConfigurationBuilder();
        configBuilder.AddJsonFile("appsettings.json", false, false);
        this.configuration = configBuilder.Build();
    }
    
    public string GetValue(string name)
    {
        return configuration[name] ?? string.Empty;
    }

    public T GetValue<T>(string name)
    {
        var value = configuration[name] ?? string.Empty;
        return (T)Convert.ChangeType(value, typeof(T));
    }
}