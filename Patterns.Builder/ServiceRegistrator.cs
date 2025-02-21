using DryIoc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Patterns.Core.Interfaces;
using Serilog;

namespace Patterns.Builder;

public class ServiceRegistrator: IServiceRegistrator
{
    #region RGU.WebProgramming.Server.Core.IServiceRegistrator implementation
    
    /// <inheritdoc cref="IServiceRegistrator.Register" />
    public void Register(
        IRegistrator registrator,
        IConfiguration configuration)
    {
        

    }
    
    
    #endregion
}