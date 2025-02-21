using DryIoc;
using Microsoft.Extensions.Logging;
using Patterns.Core.Interfaces;
using Serilog;
using Serilog.Extensions.Logging;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Client.Deploy;

internal sealed class ServicesRegistration
{

    #region Constructors
    
    public ServicesRegistration(
        IRegistrator registrator)
    {
        registrator.RegisterDelegate<ILoggerFactory>(_ =>
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddProvider(new SerilogLoggerProvider(Log.Logger));
            });
            return loggerFactory;
        }, Reuse.Singleton);
        
        var loggerFactoryMethod = typeof(LoggerFactoryExtensions).GetMethod(
            "CreateLogger",
            1,
            new[] { typeof(ILoggerFactory) }
        );

        registrator.Register(
            typeof(Microsoft.Extensions.Logging.ILogger<>),
            made: Made.Of(
                req => loggerFactoryMethod?.MakeGenericMethod(req.ServiceType.GenericTypeArguments)
            )
        );

        var loggerProviderMethod = typeof(ILoggerFactory).GetMethod("CreateLogger");

        registrator.Register(
            typeof(ILogger),
            made: Made.Of(
                req => loggerProviderMethod,
                ServiceInfo.Of<ILoggerFactory>(),
                Parameters.Of.Type(request => "Default")
            )
        );

        
        registrator.RegisterMany(
            AppDomain.CurrentDomain
                .GetAssemblies()
                .Distinct(),
            type =>
                type.ImplementsServiceType<IServiceRegistrator>()
                    ? type.GetInterfaces()
                    : null,
            type => ReflectionFactory.Of(type, Reuse.Singleton, Made.Of(), Setup.Default)
        );
        
        
    }

    
    #endregion
}