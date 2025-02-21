using DryIoc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Patterns.Adapter.Adapters;
using Patterns.Adapter.Factories;
using Patterns.Adapter.Options;
using Patterns.Adapter.Services;
using Patterns.Core.Interfaces;


namespace Patterns.Adapter;


public class ServiceRegistrator: IServiceRegistrator
{
    #region RGU.WebProgramming.Server.Core.IServiceRegistrator implementation
    
    /// <inheritdoc cref="IServiceRegistrator.Register" />
    public void Register(
        IRegistrator registrator,
        IConfiguration configuration)
    {
        
        registrator.Register<PaymentFactory>(Reuse.Singleton);
        registrator.Register<LegacyPaymentService>(Reuse.Singleton);
        registrator.Register<LegacyPaymentAdapter>(Reuse.Singleton);
        registrator.Register<NewPaymentService>(Reuse.Singleton);

        // TODO: maybe some other types will be registered
    }
    
    
    #endregion
}