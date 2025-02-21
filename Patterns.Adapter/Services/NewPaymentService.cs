using Microsoft.Extensions.Logging;
using Patterns.Adapter.Factories;
using Patterns.Adapter.Interfaces;
using Patterns.Adapter.Options;

namespace Patterns.Adapter.Services;

public class NewPaymentService : IPaymentProcessor
{
    private readonly ILogger<NewPaymentService>? _logger;

    
    public NewPaymentService(
        ILogger<NewPaymentService>? logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    
    
    public bool ProcessPayment(decimal amount, CurrencyCode currency, int customerId)
    {

        try
        {
            _logger.LogInformation($"Processing payment for {amount} for {currency}");
            
            // TODO: some logic here payment

            var resp = new PaymentResponse()
            {
                Status = StatusCode.OK
            };

            if (resp.Status != StatusCode.OK) throw new Exception("Failed to create payment!");

            _logger.LogInformation("Payment succeeded!");

            return true;

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Payment failed.");
            return false;
        }
    }

    public string GetPaymentStatus(int transactionId)
    {
        return "Paid";
    }

}