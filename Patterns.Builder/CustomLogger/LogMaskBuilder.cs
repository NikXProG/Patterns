using System.Text;

namespace Patterns.Builder.CustomLogger;

public class LogMaskBuilder
{

    private readonly StringBuilder _formatLine = new();
    
    public LogMaskBuilder WithBaseLogFormat()
    {
        this.AttachSeparator("[")
            .AttachDateTime()
            .AttachSeparator()
            .AttachLevel()
            .AttachSeparator("] ")
            .AttachMessage()
        .AttachAssembly();

        return this;
    }
    
    public LogMaskBuilder AttachAssembly()
    {
        AppendToken(LogFormat.Assembly);
        return this;
    }
    
    public LogMaskBuilder AttachSeparator(string separator = " ")
    {
        _formatLine.Append(separator);
        return this;
    }

    public LogMaskBuilder AttachLevel()
    {
        AppendToken(LogFormat.LogLevel);
        return this;
    }
    
    public LogMaskBuilder AttachDateTime()
    {
        AppendToken(LogFormat.DateTime);
        return this;
    }
    
    public LogMaskBuilder AttachMessage()
    {
        AppendToken(LogFormat.Message);
        return this;
    }
    
    private void AppendToken(LogFormat format)
    {
        _formatLine.Append($"%{format}");
    }
        
    public LogMask Build()
    {
        return new LogMask()
        {
 

            FormatLine = _formatLine.Length > 0
                ? _formatLine.ToString() : 
                $"[%{nameof(LogFormat.DateTime)} %{nameof(LogFormat.LogLevel)}] %{nameof(LogFormat.Message)} %{nameof(LogFormat.Assembly)}"
        
        };
    }

    
    // obsolete code
    public LogMaskBuilder AttachNew(string token)
    {
        
        return this;
    }

    
 
  
    
}