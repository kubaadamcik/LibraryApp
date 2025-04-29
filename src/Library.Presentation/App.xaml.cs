using System.Configuration;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Library.Infrastructure;
using Library.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ZaverecnyProjekt;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IServiceProvider _serviceProvider;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var services = new ServiceCollection();
        string dbPath = DatabaseConfig.GetDatabasePath();
        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseSqlite($"Data Source={dbPath}");
        });
        
        var serviceProvider = services.BuildServiceProvider();
    }
}