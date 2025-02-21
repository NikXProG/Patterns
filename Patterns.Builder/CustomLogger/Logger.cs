
using System.Reflection;
using System.Text;
using Patterns.Core.Interfaces;
using Serilog.Core;

namespace Patterns.Builder.CustomLogger;

public class Logger : ILogger
{
    
    private static Dictionary<string, (StreamWriter stream, long size)> _fileStreamsAll = new();
    
    private Dictionary<string, (StreamWriter stream, HashSet<LogLevel> severities)> _fileStreamsLocal;  
    
    private HashSet<LogLevel> _consoleStreamsLocal;
    
    private LogMask _logMask;
    
    private static object _objectSync = new object();
    

    public ILogger Log(string? message, LogLevel level = LogLevel.Trace)
    {
        string msg = LoggingFormat(_logMask.FormatLine, message, level);

        Console.WriteLine(msg);
        return null;
    }
    
    
    
    public ILogger LogDebug(string message)
    {
        return Log(message, LogLevel.Debug);
    }
    
    public ILogger LogTrace(string message)
    {
        return Log(message);
    }
    
    public ILogger LogInformation(string message)
    {
        return Log(message, LogLevel.Information);
    }
    
    public ILogger LogWarning(string message)
    {
        return Log(message, LogLevel.Warning);
    }
    
    public ILogger LogError(string message)
    {
        return Log(message, LogLevel.Error);
    }
    
    public ILogger LogCritical(string message)
    {
        return Log(message, LogLevel.Critical);
    }



    public LogMask LogMask
    {
        get => _logMask;
        set => _logMask = value;
    }
    
    public HashSet<LogLevel> ConsoleStreamsLocal
    {
        get => _consoleStreamsLocal;
        set => _consoleStreamsLocal = value;
    }

    public Dictionary<string, (StreamWriter stream, HashSet<LogLevel> severities)> FileStreamsLocal
    {
        get => _fileStreamsLocal;
        set => _fileStreamsLocal = value;
    }

    
    private static string LoggingFormat(
        string maskFormat, 
        string? message,
        LogLevel level = LogLevel.Trace)
    {
        
        var replacements = new Dictionary<string, string>
        {
            { $"%{nameof(LogFormat.LogLevel)}", level.ToString() },  
            {  $"%{nameof(LogFormat.Message)}", message ?? string.Empty },           
            {  $"%{nameof(LogFormat.DateTime)}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") }, 
            {$"%{nameof(LogFormat.Assembly)}", Assembly.GetEntryAssembly()?.GetName().Name ?? "UnknownAssembly" }      
        };
        
        return replacements.Aggregate(maskFormat, (current, replacement) => current.Replace(replacement.Key, replacement.Value));
        
    }
    
    
    
}