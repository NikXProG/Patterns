using Patterns.Core.Interfaces;

namespace Patterns.Facade.Services;

public class TemperatureService : ITemperatureService
{
    
    #region Fields

    private double _temperature;

    #endregion
    
    #region Methods
    
    public void SetTemperature(double temperature)
    {
        _temperature = temperature;
    }

    public double GetTemperature()
    {
        return _temperature;
    }
    
    #endregion
    
}