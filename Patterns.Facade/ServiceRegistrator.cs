using DryIoc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Patterns.Core.Interfaces;
using Patterns.Facade.Facades;
using Patterns.Facade.Services;
using Patterns.Facade.Singletons;
using Serilog;

namespace Patterns.Facade;

public class ServiceRegistrator: IServiceRegistrator
{
    #region RGU.WebProgramming.Server.Core.IServiceRegistrator implementation
    
    /// <inheritdoc cref="IServiceRegistrator.Register" />
    public void Register(
        IRegistrator registrator,
        IConfiguration configuration)
    {
        registrator.Register<Defender>(Reuse.Singleton, 
            made: Made.Of(() => Defender.Instance));
        
        registrator.Register<LightingService>(Reuse.Transient);
        registrator.Register<MusicService>(Reuse.Transient);
        registrator.Register<TemperatureService>(Reuse.Transient);
        registrator.Register<SecurityService>(Reuse.Transient);
        
        
        registrator.Register<SmartHome>(Reuse.Transient,
            Made.Of(
                () => new SmartHome(
                    Arg.Of<LightingService>(),
                    Arg.Of<MusicService>(),
                    Arg.Of<TemperatureService>(),
                    Arg.Of<SecurityService>(),
                    Arg.Of<Microsoft.Extensions.Logging.ILogger<SmartHome>>()
                ))
            );
        


    }
    
    
    #endregion
}