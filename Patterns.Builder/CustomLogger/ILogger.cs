namespace Patterns.Builder.CustomLogger;

public interface ILogger
{

    ILogger Log(string? message, LogLevel level);

    ILogger LogTrace(string message);
    
    ILogger LogDebug(string message);
    
    ILogger LogInformation(string message);
    
    ILogger LogWarning(string message);
    
    ILogger LogError(string message);
    
    ILogger LogCritical(string message);

}