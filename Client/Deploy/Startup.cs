using System.Reflection;
using Client.AssemblyInfo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;


namespace Client.Deploy;

public static class Startup
{
    #region Fields

    private static string _rootPath;
    private static Dictionary<string, PatternModel> _modules;

    #endregion

    #region Methods

    /// <summary>
    /// Запускает клиентское приложение, загружает зависимости и модули.
    /// </summary>
    public static IServiceProvider ConfigureApplication()
    {
        _rootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
        Directory.SetCurrentDirectory(_rootPath);
        
        var configuration = BuildConfiguration();


        Log.Logger = BuildLogger(configuration);
        Log.Information("Client application starting...");


        var serviceCollection = new ServiceCollection();
        
        
        serviceCollection.AddSingleton<IConfiguration>(configuration);
       
        LoadModules(configuration);
        
        IContainer container = new Container();
        
        container.RegisterInstance(_modules);
        container.RegisterInstance(configuration);
        
        container = container
            .WithCompositionRoot<ServicesRegistration>()
            .WithCompositionRoot<Patterns.Core.Interfaces.ServiceRegistratorsCompositionRoot>();

        return container.Resolve<IServiceProvider>();
    }

    /// <summary>
    /// Создаёт конфигурацию приложения.
    /// </summary>
    private static IConfiguration BuildConfiguration()
    {
        Environment.SetEnvironmentVariable("BASEDIR", _rootPath);
        
        return new ConfigurationBuilder()
            .SetBasePath(_rootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ENVIRONMENT")}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();
    }

    /// <summary>
    /// Настраивает Serilog из конфигурации.
    /// </summary>
    private static ILogger BuildLogger(IConfiguration configuration)
    {
        return new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();
    }

    /// <summary>
    /// Загружает и регистрирует модули из конфигурации.
    /// </summary>
    private static void LoadModules(IConfiguration configuration)
    {
        
        CatchUnhandledExceptions();
       
        configuration.Bind("Patterns", _modules = new Dictionary<string, PatternModel>() );

        foreach (var module in _modules.Where(m => m.Value.Enabled))
        {
            var assemblyPath = Path.Combine(_rootPath, module.Value.AssemblyName);
            
            if (File.Exists(assemblyPath))
            {
                Log.Information("Loading module {Module} from {Assembly}", module.Key, module.Value.AssemblyName);
                Assembly.LoadFrom(assemblyPath);
                continue;
            }
            
            Log.Warning("Assembly {Assembly} not found for module {Module}. Skipping...", module.Value.AssemblyName, module.Key);
  
        }
    }

    /// <summary>
    /// Обрабатывает необработанные исключения.
    /// </summary>
    private static void CatchUnhandledExceptions()
    {
        AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
        {
            Log.Fatal($"Unhandled exception occurred: {(e.ExceptionObject as Exception)?.Message}");
        };
    }

    #endregion
}