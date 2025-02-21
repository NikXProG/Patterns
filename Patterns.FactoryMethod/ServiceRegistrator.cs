using DryIoc;
using Microsoft.Extensions.Configuration;
using Patterns.Core.Interfaces;
using Patterns.FactoryMethod.Factories;

namespace Patterns.FactoryMethod;


public class ServiceRegistrator: IServiceRegistrator
{
    #region RGU.WebProgramming.Server.Core.IServiceRegistrator implementation
    
    /// <inheritdoc cref="IServiceRegistrator.Register" />
    public void Register(
        IRegistrator registrator,
        IConfiguration configuration)
    {
 
        

        registrator.RegisterMany<WarriorFactory>(Reuse.Singleton);
        
        registrator.RegisterMany<ArcherFactory>(Reuse.Singleton);
        
        registrator.RegisterMany<MageFactory>(Reuse.Singleton);

        // TODO: maybe some other types will be registered
    }
    
    
    #endregion
}