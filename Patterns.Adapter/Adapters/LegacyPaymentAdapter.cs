using  Microsoft.Extensions.Logging;
using Patterns.Adapter.Interfaces;
using Patterns.Adapter.Options;
using Patterns.Adapter.Services;


namespace Patterns.Adapter.Adapters;

public class LegacyPaymentAdapter : IPaymentProcessor
{
    private readonly LegacyPaymentService _service;
    
    private readonly ILogger<LegacyPaymentAdapter>? _logger;

    
    public LegacyPaymentAdapter(
        LegacyPaymentService service,
        ILogger<LegacyPaymentAdapter>? logger)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public bool ProcessPayment(decimal amount, CurrencyCode currency, int customerId)
    {
        return _service.MakePayment(amount, customerId);
    }
    
    public string GetPaymentStatus(int transactionId)
    {
        return _service.CheckStatus(transactionId);
   
    }
    
    
    
    
}
