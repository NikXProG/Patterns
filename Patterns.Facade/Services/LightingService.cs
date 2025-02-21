using Microsoft.Extensions.Logging;
using Patterns.Core.Interfaces;

namespace Patterns.Facade.Services;

public class LightingService : ILightingService
{
    #region Fields

    private bool _isOn;
    
    private readonly  Microsoft.Extensions.Logging.ILogger<LightingService>? _logger;

    #endregion

    
    
    #region Constructors

    public LightingService(
        Microsoft.Extensions.Logging.ILogger<LightingService>? logger = null)
    {
        _logger = logger;
    }

    #endregion
    
    #region Methods
    
    public void LightOn()
    {
        IsOn = true;
        _logger?.LogInformation("Light is on");
    }
    
    public void LightOff()
    {
        IsOn = false;
        _logger?.LogInformation("Light is off");
    }
    
    #endregion
    
    #region Properties
    public bool IsOn
    {
        get => _isOn;
        private set => _isOn = value;
    }
    
    #endregion

}
