    using LocadoraDeVeiculos.Infra.Logging;
using LocadoraDeVeiculos.WinApp.Compartilhado.ServiceLocator;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConfiguracaoLogsLocadora.ConfigurarEscritaLogs();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            

            var serviceLocatorAutofac = new ServiceLocatorComAutofac();

            Application.Run(new TelaMenuPrincipalForm(serviceLocatorAutofac));
        }

        


    }
}
