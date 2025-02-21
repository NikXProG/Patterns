using Microsoft.Extensions.Logging;
using Patterns.Facade.Services;

namespace Patterns.Facade.Facades;

public sealed class SmartHome
{
    
    #region Fields

    private readonly ServiceConnector _connector = new();
    private readonly  ILogger<SmartHome>? _logger;
    private readonly LightingService _lightingService;
    private readonly MusicService _musicService;
    private readonly TemperatureService _temperatureService;
    private readonly SecurityService _securityService;
    
    #endregion
    
    #region Constructors
    public SmartHome(
        LightingService lightingService,
        MusicService musicService,
        TemperatureService temperatureService,
        SecurityService securityService,
        ILogger<SmartHome>? logger = null)
    {
        _logger = logger;
        _lightingService = lightingService;
        _musicService = musicService;
        _temperatureService = temperatureService;
        _securityService = securityService;
  
    }
    #endregion
    
    #region Methods
    
    
    
    
    public void StartHome()
    {
        
        _connector.Connect();
        _logger?.LogInformation("Smart Home started.");
    }
    
    public void ActivateEveningMode()
    {
        _lightingService.LightOn();
        _musicService.Play();
        _temperatureService.SetTemperature(15);
        _logger?.LogInformation("Evening Mode activated.");
    }
    
    public void ActivateNightMode()
    {
        _lightingService.LightOff();
        _musicService.Stop();
        _securityService.AuthenticateUser();
        _temperatureService.SetTemperature(0);
        _logger?.LogInformation("Night Mode activated.");
    }

    public void LeaveHome()
    {
        _connector.Disconnect();
        _logger?.LogInformation("Left Home.");
    }
    
    
    #endregion
    
}