﻿using System.Configuration;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using Library.Application.Interfaces;
using Library.Application.Services;
using Library.Domain.Entities;
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
    private IServiceProvider _serviceProvider { get; set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        ThemeManager.Instance.SetTheme(false);

        var services = new ServiceCollection();
        string dbPath = DatabaseConfig.GetDatabasePath();
        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseSqlite($"Data Source=../../../../Library.Infrastructure/library.db");
        });

        services.AddSingleton<Reader>();
        
        services.AddSingleton<ILibraryService, LibraryService>();
        services.AddSingleton<IBookService, BookService>();
        services.AddSingleton<IBookTransactionService, BookTransactionService>();
        services.AddSingleton<IReaderService, ReaderService>();

        services.AddTransient<MainWindow>();

        _serviceProvider = services.BuildServiceProvider();

        var mainWindow = _serviceProvider.GetService<MainWindow>();
        mainWindow.Show();

    }

}