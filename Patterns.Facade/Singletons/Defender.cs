namespace Patterns.Facade.Singletons;

public sealed class Defender
{
    
    #region Fields

    private static readonly Lazy<Defender> Lazy =
        new Lazy<Defender>(() => new Defender());

    #endregion

    #region Constructors
    private Defender()
    {
        
    }
    
    #endregion
    
    #region Properties
    
    public static Defender Instance => Lazy.Value;
    
    #endregion
}