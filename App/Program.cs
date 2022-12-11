
using App.Client_Interface;
using App.Controllers;
using App.RestSharpClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.Design;

namespace App
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;
        }

        public static IServiceProvider ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {

                    //Add services
                    services.AddSingleton<IAuthenticationClient, AuthenticationClient>();
                    services.AddSingleton<AuthenticationController>();

                });
        }
    }
}