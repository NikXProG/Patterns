using Patterns.Core.Interfaces;
using Patterns.Facade.Singletons;

namespace Patterns.Facade.Services;

public class SecurityService : ISecurityService
{
    
    #region Fields

    /// <summary>
    /// The defender is implemented via Singleton :)
    /// </summary>
    private readonly Defender _defender;
    
    #endregion
    
    #region Constructurs

    public SecurityService(Defender defender)
    {
        _defender = defender;
    }
    
    #endregion
    
    #region Methods

    public void AuthenticateUser()
    {
        // your code may be here
    }
    
    public void LogOut()
    {
        // your code may be here
    }
    
    #endregion
    
}