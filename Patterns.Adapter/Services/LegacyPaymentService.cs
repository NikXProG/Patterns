using Microsoft.Extensions.Logging;

namespace Patterns.Adapter.Services;

public class LegacyPaymentService
{
    private readonly ILogger<LegacyPaymentService>? _logger;

    
    public LegacyPaymentService(
        ILogger<LegacyPaymentService>? logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    
    public bool MakePayment(decimal money, int userId)
    {
        _logger.LogInformation("ПУК ПУК СРЕНЬК СТАРЫЙ СЕРВИС method {method:G}", nameof(MakePayment));
        return true;
    }

    public string CheckStatus(int txnId)
    {
        _logger.LogInformation("ПУК ПУК СРЕНЬК СТАРЫЙ СЕРВИС method {method:G}", nameof(CheckStatus));
        return null;
    }
    
}