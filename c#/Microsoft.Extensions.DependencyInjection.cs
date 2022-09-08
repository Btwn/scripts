using Microsoft.Extensions.DependencyInjection;
using System;

namespace WinFormsApp1
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

            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                Form1 form1 = serviceProvider.GetRequiredService<Form1>();
                Application.Run(form1);
            }

            //IUser user = new User();
            //var form2 = new Form1(user);
            //Application.Run(form2);

        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services
                .AddScoped<IUser, User>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<Form1>();
        }
    }
}
