
using App.Cache;
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
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ApplicationConfiguration.Initialize();

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<LoginForm>());

            if(Globals.Authenticated){
                Application.Run(new MainForm());
            }
                
        }

        public static IServiceProvider ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {

                    //Add services
                    //..
                    //Client  services
                    string authUrl = "https://localhost:44346/api/v1/authentication";
                    IAuthenticationClient authenticationClient = new AuthenticationClient(authUrl);
                    services.AddScoped<IAuthenticationClient>((cs) => authenticationClient);

                    //services.AddSingleton<IAuthenticationClient, AuthenticationClient>();
                    services.AddSingleton<AuthenticationController>();

                    //Controllers
                    services.AddSingleton<LoginForm>();



                });
        }
    }
}