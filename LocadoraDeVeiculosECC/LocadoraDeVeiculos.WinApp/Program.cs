    using LocadoraDeVeiculos.Infra.Logging;
using LocadoraDeVeiculos.Infra.Orm;
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
            MigradorBancoDadosLocadoraDeVeiculos.AtualizarBancoDados();
            ConfiguracaoLogsLocadora.ConfigurarEscritaLogs();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TelaMenuPrincipalForm(new ServiceLocatorManual()));
        }
    }
}
