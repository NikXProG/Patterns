using Patterns.Adapter.Options;

namespace Patterns.Adapter.Interfaces;

public interface IPaymentProcessor
{
    bool ProcessPayment(decimal amount, CurrencyCode currency, int customerId);
    string GetPaymentStatus(int transactionId);
}