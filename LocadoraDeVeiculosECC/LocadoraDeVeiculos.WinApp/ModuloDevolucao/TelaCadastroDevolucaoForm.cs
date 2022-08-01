﻿using FluentResults;
using LocadoraDeVeiculos.Aplicacao.ModuloLocacao;
using LocadoraDeVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
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


        List<Locacao> locacoes ;
        List<PlanoDeCobranca> planoDeCobrancas; 
        

        public TelaCadastroDevolucaoForm(ServicoLocacao servicoLocacao, ServicoTaxa servicoTaxa , ServicoPlanoDeCobranca servicoPlanoDeCobranca)
        {
            InitializeComponent();
            this.servicoLocacao = servicoLocacao;
            this.servicoTaxa = servicoTaxa;
            this.servicoPlanoDeCobranca = servicoPlanoDeCobranca;
            planoDeCobrancas = servicoPlanoDeCobranca.SelecionarTodos().Value;
            locacoes = servicoLocacao.SelecionarTodos().Value;
            CarregarLocacoes(locacoes);
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
                    dtpDataDeDevolucao.Value = DateTime.Now.Date;

                }
                cmbLocacao.SelectedItem = devolucao.Locacao;
                txtValorTotal.Text = devolucao.ValorTotal.ToString();

            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            foreach (var item in locacoes)
            {

                if (item.Id.Equals(cmbLocacao.SelectedItem))
                    devolucao.Locacao = item;

            }
            devolucao.KmVeiculo = Convert.ToInt32(txtKmDoVeiculo.Text);
            devolucao.DataDeDevolucao = dtpDataDeDevolucao.Value;

            decimal parteDoValor = calcularValorFinal();
            devolucao.ValorTotal = devolucao.Locacao.ValorTotalPrevisto + parteDoValor;
            

            var resultadoValidacao = GravarRegistro(devolucao);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaMenuPrincipalForm.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
        }

        //Métodos Privados

        private void CarregarLocacoes(List<Locacao> locacoes)
        {
            foreach (var locacao in locacoes)
            {

                cmbLocacao.Items.Add(locacao.Id);

            }
        }

        private void cmbLocacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in locacoes)
            {

                if (item.Id.Equals(cmbLocacao.SelectedItem))
                    devolucao.Locacao = item;

            }

            //  txtGrupoDeVeiculo.Text = devolucao.Locacao.Veiculo.GrupoDeVeiculos.Nome;
            //  txtVeiculo.Text = $"{devolucao.Locacao.Veiculo}  - {devolucao.Locacao.Veiculo}";
            txtFuncionario.Text = devolucao.Locacao.Funcionario.Nome;
            txtCliente.Text = devolucao.Locacao.Cliente.Nome;
            txtDataDeLocacao.Text = devolucao.Locacao.DataLocacao.ToShortDateString();
            txtDevolucaoPrevista.Text = devolucao.Locacao.DataDevolucaoPrevista.ToShortDateString();
            txtPlanoDeCobranca.Text = devolucao.Locacao.PlanoDeCobranca.ToString();
            txtValorTotal.Text = devolucao.Locacao.ValorTotalPrevisto.ToString();
            // totalComTaxa = devolucao.CalcularTaxas();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            devolucao.NivelDoTanque = comboBox1.SelectedIndex;
        }

        private decimal calcularValorFinal()
        {
            decimal valorFinal = 0;

            //Cálculo aqui

            return valorFinal;
        }
    }
}
