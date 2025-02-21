using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Patterns.Adapter.Interfaces;
using Patterns.Adapter.Options;
using Patterns.Adapter.Services;
using Patterns.Core;

namespace Patterns.Adapter.Factories;


public class PaymentFactory
{
    private readonly IServiceProvider _serviceProvider;
    
    public PaymentFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
    }
    
    public T Create<T>() where T : IPaymentProcessor
    {
        return ActivatorUtilities.CreateInstance<T>(_serviceProvider);
    }
   
    
}