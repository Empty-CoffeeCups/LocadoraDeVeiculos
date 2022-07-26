using locadoraDeVeiculos.Infra.ModuloCliente;
using locadoraDeVeiculos.Infra.ModuloCondutor;
using locadoraDeVeiculos.Infra.ModuloFuncionario;
using locadoraDeVeiculos.Infra.ModuloPlanoDeCobranca;
using locadoraDeVeiculos.Infra.ModuloTaxas;
using locadoraDeVeiculos.Infra.ModuloVeiculo;
using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxas;
using LocadoraDeVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.WinApp.Compartilhado.ServiceLocator;
using LocadoraDeVeiculos.WinApp.ModuloCliente;
using LocadoraDeVeiculos.WinApp.ModuloCondutor;
using LocadoraDeVeiculos.WinApp.ModuloFuncionario;
using LocadoraDeVeiculos.WinApp.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.WinApp.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.WinApp.ModuloTaxas;
using LocadoraDeVeiculos.WinApp.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinFormsApp.Compartilhado
{
    public partial class TelaMenuPrincipalForm : Form
    {
        private ControladorBase controlador;
        private readonly IServiceLocator serviceLocator;

        public TelaMenuPrincipalForm(IServiceLocator serviceLocator)
        {
            InitializeComponent();

            this.ConfigurarTela();

            Instancia = this;

            labelRodape.Text = string.Empty;
            labelTipoCadastro.Text = string.Empty;
            this.serviceLocator = serviceLocator;
        }

        public static TelaMenuPrincipalForm Instancia
        {
            get;
            private set;
        }

        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }
        private void clientesMenuItem_Click(object sender, EventArgs e)
        {
            // ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorClientes>());
        }

        private void funcionariosMenuItem_Click(object sender, EventArgs e)
        {
            //ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorFuncionarios>());
        }

        private void grupoDeVeiculosMenuItem_Click(object sender, EventArgs e)
        {
           // ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorGrupoDeVeiculos>());
        }

        private void planosDeCobrançaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorPlanoDeCobranca>());
        }

        private void taxasMenuItem_Click(object sender, EventArgs e)
        {
           // ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorTaxas>());
        }

        private void condurtoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorCondutores>());
        }
        private void veiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorVeiculo>());
        }
        private void btnInserir_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }
        private void ConfigurarBotoes(ConfiguracaoToolBoxBase configuracao)
        {
            btnInserir.Enabled = configuracao.InserirHabilitado;
            btnEditar.Enabled = configuracao.EditarHabilitado;
            btnExcluir.Enabled = configuracao.ExcluirHabilitado;
        }

        private void ConfigurarTooltips(ConfiguracaoToolBoxBase configuracao)
        {
            btnInserir.ToolTipText = configuracao.TooltipInserir;
            btnEditar.ToolTipText = configuracao.TooltipEditar;
            btnExcluir.ToolTipText = configuracao.TooltipExcluir;
        }

        private void ConfigurarTelaPrincipal(ControladorBase controlador)
        {
            this.controlador = controlador;

            ConfigurarToolbox();

            ConfigurarListagem();
        }
        private void ConfigurarToolbox()
        {
            ConfiguracaoToolBoxBase configuracao = controlador.ObtemConfiguracaoToolbox();

            if (configuracao != null)
            {
                toolbox.Enabled = true;

                labelTipoCadastro.Text = configuracao.TipoCadastro;

                ConfigurarTooltips(configuracao);

                ConfigurarBotoes(configuracao);
            }
        }
        private void ConfigurarListagem()
        {
            AtualizarRodape("");

            var listagemControl = controlador.ObtemListagem();

            panelRegistros.Controls.Clear();

            listagemControl.Dock = DockStyle.Fill;

            panelRegistros.Controls.Add(listagemControl);
        }

       

        
    }

}
