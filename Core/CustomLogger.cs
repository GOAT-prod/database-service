using Core.Intefraces;
using Microsoft.Extensions.Logging;

namespace Core;

public class CustomLogger(ISettings settings) : ILogger
{
    private LogLevel MinLogLevel => Enum.Parse<LogLevel>(settings.GetValue("Logging:LogLevel:Default"));
    
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string>? formatter)
    {
        if (!IsEnabled(logLevel))
            return;

        var message = $"{state} \n {exception?.Message}";

        if (formatter != null)
        {
            message = formatter(state, exception);
        }
        
        if (string.IsNullOrEmpty(message))
            return;

        var logEntry = $"[{DateTime.UtcNow:u}] [{logLevel}] {message}";

        Console.WriteLine(logEntry);
    }
    
    public bool IsEnabled(LogLevel logLevel)
    {
        return logLevel >= MinLogLevel;
    }
    
    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        return null;
    }
}