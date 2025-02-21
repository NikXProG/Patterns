using Microsoft.Extensions.Logging;
using Patterns.Core.Interfaces;

namespace Patterns.Facade.Services;

public class MusicService : IMusicService
{
    
    private readonly  Microsoft.Extensions.Logging.ILogger<MusicService>? _logger;
    
    
    #region Constructors
    public MusicService(
        Microsoft.Extensions.Logging.ILogger<MusicService>? logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    
    #endregion

    public void Play()
    {
        _logger?.LogInformation("Play");
    }
    public void Pause()
    {
        _logger?.LogInformation("Pause");
    }

    public void Stop()
    {
        _logger?.LogInformation("Stop");
    }

    public void Reset()
    {
        _logger?.LogInformation("Reset");
    }

    public void SetVolume(float volume)
    {
        _logger?.LogInformation("SetVolume");
    }

    public void Next()
    {
        _logger?.LogInformation("Next");
    }

    public void Last()
    {
        _logger?.LogInformation("Last");
    }
    
}