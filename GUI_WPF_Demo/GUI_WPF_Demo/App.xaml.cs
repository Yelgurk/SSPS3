using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Runtime.CompilerServices;

namespace GUI_WPF_Demo;

public partial class App : Application
{
    public static IHost? AppHost { get; private set; }

    public App()
    {
        AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<MainWindow>();
                services.AddSingleton<FirstPage>();
                services.AddSingleton<SecondPage>();
                services.AddTransient<IWindowContentService, WindowContentService>();
            })
            .Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await AppHost!.StartAsync();

        MainWindow StartUpWindow = AppHost!.Services.GetRequiredService<MainWindow>()!;
        StartUpWindow.Content = AppHost!.Services.GetRequiredService<FirstPage>()!;
        StartUpWindow.Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await AppHost!.StopAsync();
        base.OnExit(e);
    }
}

public interface IWindowContentService
{
    public void Set<T>() where T : notnull;
}

public class WindowContentService : IWindowContentService
{
    void IWindowContentService.Set<T>() => App.AppHost!.Services.GetRequiredService<MainWindow>()!.Content = App.AppHost!.Services.GetRequiredService<T>()!;
}