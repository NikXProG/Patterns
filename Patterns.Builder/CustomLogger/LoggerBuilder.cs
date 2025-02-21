using Microsoft.Extensions.Logging;
using Patterns.Core.Interfaces;
using ILogger = Patterns.Builder.CustomLogger.ILogger;

namespace Patterns.Builder.CustomLogger;

public class LoggerBuilder : ILoggerBuilder
{
     
     private Dictionary<string, HashSet<LogLevel>>  _filesStreams= new();
     
     private HashSet<LogLevel> _consoleStreams= new();
     
     private LogMaskBuilder _logMaskBuilder = new LogMaskBuilder();
     
     public ILoggerBuilder WithConsoleStream(LogLevel level = LogLevel.Debug)
     {
          WithConsoleStream(MinBoundaryLogLevel(level));
          
          return this;
     }
     
     public ILoggerBuilder WithConsoleStream(HashSet<LogLevel> levels)
     {
          _consoleStreams.UnionWith(levels);
          return this;
     }
     
     
     public ILoggerBuilder WithFileStream(
          string path, 
          LogLevel level = LogLevel.Debug)
     {
          WithFileStream(path, MinBoundaryLogLevel(level));
          return this;
     }
     
     public ILoggerBuilder WithFileStream(
          string path, 
          HashSet<LogLevel> levels)
     {
          var absolutePath = Path.GetFullPath(path);
          
          if (!_filesStreams.TryGetValue(absolutePath, out var value))
          {
            value = new HashSet<LogLevel>();
            _filesStreams[absolutePath] = value;
          }

          value.UnionWith(levels);

          return this;
     }
     
     
     
     
     
     
     public ILoggerBuilder ConfigureMask(Action<LogMaskBuilder> action)
     {
          action(_logMaskBuilder);
          return this;
     }
     
     
     private HashSet<LogLevel> MinBoundaryLogLevel(LogLevel lvl)
     {
          var levels = new HashSet<LogLevel>();

          switch (lvl)
          {
               case LogLevel.Trace: levels.Add(LogLevel.Trace); break;
               case LogLevel.Debug: levels.Add(LogLevel.Debug); break;
               case LogLevel.Information: levels.Add(LogLevel.Information); break;
               case LogLevel.Warning: levels.Add(LogLevel.Warning); break;
               case LogLevel.Error: levels.Add(LogLevel.Error); break;
               case LogLevel.Critical: levels.Add(LogLevel.Critical); break;
          }

          return levels;
          
     }
     
   
     

     public ILogger Build()
     {
          return new Logger()
          {
               ConsoleStreamsLocal = _consoleStreams,
               LogMask = _logMaskBuilder.Build(),
          };
     }
     

     
    
}