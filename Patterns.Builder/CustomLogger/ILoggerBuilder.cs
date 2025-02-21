namespace Patterns.Builder.CustomLogger;

public interface ILoggerBuilder
{
    ILoggerBuilder WithFileStream(string streamFilePath, LogLevel level);
    
    ILoggerBuilder WithConsoleStream(LogLevel level);
    
    /*ILoggerBuilder TransformWithConfiguration(
        string configurationFilePath,
        string configurationPath);*/
    
    // ILoggerBuilder Clear();
    
    ILogger Build();
    
}