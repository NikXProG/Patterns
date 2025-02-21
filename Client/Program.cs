using Client.Deploy;
using Microsoft.Extensions.DependencyInjection;
using Patterns.Adapter.Adapters;
using Patterns.Adapter.Factories;
using Patterns.Adapter.Options;
using Patterns.Adapter.Services;
using Patterns.Builder.CustomLogger;
using Patterns.Domain.Models;
using Patterns.Facade.Facades;
using Patterns.FactoryMethod.Factories;
using Serilog;

namespace Client
{
    
    class Program
    {

       
     
        public static int Main(string[] args)
        {
            
            try
            {

                var serviceProvider = Startup.ConfigureApplication();
                
                Log.Information("\x1b[36mApplication running...");
                
                #region Facade Example
                
                Log.Information("\x1b[32mStarted Facade Example...");
                
                var smartHome = serviceProvider.GetRequiredService<SmartHome>();
                
                smartHome.ActivateEveningMode();
                
                smartHome.ActivateNightMode();
                
                var smartHome1 = serviceProvider.GetRequiredService<SmartHome>();
                
                smartHome1.ActivateEveningMode();
                
                Log.Information("\x1b[33mFinished Facade Example...");
                
                #endregion
                
                #region Factory Method Example
                
                     Log.Information("\x1b[32mStarted Factory Method Example...");
                
                    var factory = serviceProvider.GetRequiredService<ArcherFactory>();

                     var archer = factory.Create(new CharacterModel()
                     {
                         Name = "sdsdsds",
                         Health = 70
                     });
                     
                     
                     var  mageFactory = serviceProvider.GetRequiredService<MageFactory>();
                     
                     var mage = mageFactory.Create(new CharacterModel()
                     {
                         Name = "Voin",
                         Health = 100
                     });

                     var mageClone = mage.Clone();
                     
                     Log.Information($"{nameof(mage)} : {mage}");
                     
                     Log.Information($"{nameof(mageClone)} : {mageClone}");

                     Log.Information($"{nameof(archer)} : {archer}");
                     
                     Log.Information("\x1b[33mFinished Factory Method Example...");

                 #endregion

                 #region Builder Example
                 
                     Log.Information("\x1b[32mStarted Builder Example...");

                     var logger = new LoggerBuilder()
                         .ConfigureMask(b=>
                             b.WithBaseLogFormat()
                             .Build()
                         )
                         .WithConsoleStream(LogLevel.Debug)
                         .WithFileStream("text.txt", LogLevel.Debug)
                         .Build();
                     
                     logger.Log("\x1b[36mStarted Log Example...\x1b[0m", LogLevel.Error);
                     logger.Log("\x1b[33mLet's drink beer!...\x1b[0m", LogLevel.Information);
                     logger.Log("\x1b[32mFirst logger...\x1b[0m", LogLevel.Debug);
                         
                     Log.Information("\x1b[33mFinished Builder Example...");

                 #endregion
                 
                 #region Adapter Example
                 
                 Log.Information("\x1b[32mStarted Adapter Example...");
                 
                 var factoryServices = serviceProvider.GetRequiredService<PaymentFactory>();

                 var newService = factoryServices.Create<NewPaymentService>();
                 var adapter = factoryServices.Create<LegacyPaymentAdapter>();
                 
                 adapter.ProcessPayment(2131.123m, CurrencyCode.USD, 232);
                 newService.ProcessPayment(2131.123m, CurrencyCode.USD, 232);
                 
                 Log.Information("\x1b[33mFinished Adapter Example...");
                
                 
                 #endregion
                 
                 return 0;
                 
            }
            catch (Exception ex)
            {
                Log.Logger?.Fatal(ex, "Application start up failed");
                return ex.HResult;
            }
            finally
            {
                
                Log.Information("\x1b[36mApplication closed");
                Log.CloseAndFlush();
                
            }
            
        }
        
       
      
    }


}


// abstract factory as a special case of a factory method
/*
var humanFactory = new ArcherFactory();

var war1 = humanFactory.Create(new CharacterModel()
{
    Name = "sdsdsds",
    Health = 70
});

var war2 = humanFactory.Create(new CharacterModel()
{
    Name = "aasasasa",
    Health = 550
});

var war3 = (Archer)humanFactory.Create(new CharacterModel()
{
    Name = "Voin",
    Health = 100
});

var warClone = (Archer)war3.Clone();
Console.WriteLine(warClone.Damage);
Console.WriteLine(warClone.RadiusBow);
Console.WriteLine(war3.RadiusBow);
Console.WriteLine(war3.Damage);



Console.WriteLine(war1.Name);
Console.WriteLine(war2.Name);
Console.WriteLine(war2.Health);
Console.WriteLine(war3.Name);
Console.WriteLine(war3.Health);
*/
            
            
            
// using var loggerFactory = LoggerFactory.Create(builder =>
// {
//     builder.AddConsole(); // Логирование в консоль
// });
//
// ILogger<SmartHome> logger = loggerFactory.CreateLogger<SmartHome>();
            
/*
SmartHome home = new SmartHome(new ServiceConnector(), logger);

home.StartHome();
home.ActivateNightMode();
home.LeaveHome();
*/

