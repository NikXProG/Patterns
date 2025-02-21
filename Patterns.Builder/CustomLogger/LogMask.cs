using System.Text;
using Patterns.Domain.Models;

namespace Patterns.Builder.CustomLogger;


/// <summary>
/// set of types for log output
/// </summary>


//obsolete code
public enum LogFormat
{
    Assembly = 0,
    Message,
    LogLevel,
    Timestamp,
    NewLine,
    Date,
    DateTime,
    Separator
}


public class LogMask
{

    public string FormatLine { get; set; }
    
    public override string ToString()
    {
        return FormatLine.ToString();
    }
    
    
    
    
    
    
        
}