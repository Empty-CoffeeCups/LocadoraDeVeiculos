using FluentResults;
using LocadoraDeVeiculos.Aplicacao.ModuloLocacao;
using LocadoraDeVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloDevolucao
{
    public partial class TelaCadastroDevolucaoForm : Form
    {
        public Devolucao devolucao;
        private ServicoLocacao servicoLocacao;
        private ServicoTaxa servicoTaxa;
        private ServicoPlanoDeCobranca servicoPlanoDeCobranca;


        List<Locacao> locacoes;
        List<PlanoDeCobranca> planoDeCobrancas; 
        

        public TelaCadastroDevolucaoForm(ServicoLocacao servicoLocacao, ServicoTaxa servicoTaxa , ServicoPlanoDeCobranca servicoPlanoDeCobranca)
        {
            InitializeComponent();
            this.servicoLocacao = servicoLocacao;
            this.servicoTaxa = servicoTaxa;
            this.servicoPlanoDeCobranca = servicoPlanoDeCobranca;
            planoDeCobrancas = servicoPlanoDeCobranca.SelecionarTodos().Value;
            locacoes = servicoLocacao.SelecionarTodos().Value;
            locacoes = servicoLocacao.SelecionarTodos().Value;
        }

        public Func<Devolucao, Result<Devolucao>> GravarRegistro { get; set; }



        public Devolucao Devolucao
        {
            get
            {
                return devolucao;
            }
            set
            {
                devolucao = value;
                if (devolucao.Locacao != null)
                {
                    txtFuncionario.Text = devolucao.Locacao.Funcionario.Nome;
                    txtCliente.Text = devolucao.Locacao.Cliente.Nome;
                    // txtVeiculo.Text = devolucao.Locacao.Veiculo; -- esperando o merge do módulo veículo 
                    // txtGrupoDeVeiculo.Text = devolucao.veiculo.GrupoDeVeiculo.NomeDoGrupo; --  -- esperando o merge do módulo veículo
                    txtDataDeLocacao.Text = devolucao.Locacao.DataLocacao.ToShortDateString();
                    txtDevolucaoPrevista.Text = devolucao.Locacao.DataDevolucaoPrevista.ToShortDateString();
                    txtPlanoDeCobranca.Text = devolucao.Locacao.PlanoDeCobranca.ToString();

                }
                cmbLocacao.SelectedItem = devolucao.Locacao;
                txtValorTotal.Text = devolucao.ValorTotal.ToString();

            }
        }

    }
}
