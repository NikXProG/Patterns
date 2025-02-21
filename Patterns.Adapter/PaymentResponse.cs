namespace Patterns.Adapter;

// too lazy to add more :)
public enum StatusCode {
    OK = 0,
}


public class PaymentResponse
{
    
    public StatusCode Status {
        get;
        set; 
    }
    
}