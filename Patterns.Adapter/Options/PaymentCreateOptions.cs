namespace Patterns.Adapter.Options;

public enum CurrencyCode
{
    USD = 0, 
    EUR,  
    GBP,  
    JPY,  
    RUB, 
    CNY, 
    INR,  
    AUD   
}



public class PaymentCreateOptions
{

    
    public decimal Amount
    {
        get; 
        set;
    }


    public CurrencyCode Currency
    {
        get;
        set;
    }
    
    public string Customer
    {
        get;
        set;
    }
    
    
    
}