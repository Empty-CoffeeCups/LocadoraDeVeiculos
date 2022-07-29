﻿using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloLocacao
{
    public partial class TelaCadastroLocacaoForm : Form
    {
        private Locacao locacao = new Locacao();
        List<Taxas> taxas = new List<Taxas>();

        public TelaCadastroLocacaoForm(List<Funcionario> funcionarios,List<Cliente> clientes, List<Condutor> condutores, /*List<Veiculo> veiculos,*/ List<PlanoDeCobranca> planos, List<Taxas> taxas)
        {
            InitializeComponent();
            CarregarClientes(clientes);
            CarregarFuncionarios(funcionarios);
            CarregarCondutores(condutores);
           // CarregarVeiculos(veiculos); -- esperando merge de modulo veiculo
            CarregarPlanosDeCobranca(planos);
            CarregarTaxas(taxas);
        }

        public Func<Locacao, Result<Locacao>> GravarRegistro { get; set; }


        public Locacao Locacao
        {
            get
            {
                return locacao;
            }
            set
            {
                locacao = value;

                cmbCliente.SelectedItem = locacao.Cliente;
                cmbFuncionario.SelectedItem = locacao.Funcionario;
                cmbCondutor.SelectedItem = locacao.Condutor;
                cmbPlanoDeCobranca.SelectedItem = locacao.PlanoDeCobranca;
              //  cmbVeiculo.SelectedItem = locacao.Veiculo; -- esperando merge de modulo veiculo

                dtpDataDeLocacao.Value = DateTime.Now.Date;
                dtpDevolucaoPrevista.Value = DateTime.Now.Date;

                //  txtKmRodado.Text = locacao.veiculo.kmRodado; -- esperando merge de modulo veiculo
                //   txtGrupoDeVeiculos.Text = locacao.veiculo.GrupoDeVeiculo.NomeDoGrupo; -- esperando merge de modulo veiculo


                txtValorTotalPrevisto.Enabled = false;
                txtKmRodado.Enabled = false;
                txtGrupoDeVeiculos.Enabled = false;

                if (locacao.Taxas != null)
                {
                    foreach (var item in locacao.Taxas)
                    {
                        listTaxas.Items.Add(item);
                    }
                }


            }
        }

        private void CarregarClientes(List<Cliente> clientes)
        {
            cmbCliente.Items.Clear();

            foreach (var item in clientes)
            {
                cmbCliente.Items.Add(item);
            }
        }


        private void CarregarFuncionarios(List<Funcionario> funcionarios)
        {
            cmbFuncionario.Items.Clear();

            foreach (var item in funcionarios)
            {
                cmbFuncionario.Items.Add(item);
            }
        }


        private void CarregarCondutores(List<Condutor> condutores)
        {
            cmbCondutor.Items.Clear();

            foreach (var item in condutores)
            {
                cmbCondutor.Items.Add(item);
            }
        }

        private void CarregarPlanosDeCobranca(List<PlanoDeCobranca> planos)
        {
            cmbPlanoDeCobranca.Items.Clear();

            foreach (var item in planos)
            {
                cmbPlanoDeCobranca.Items.Add(item);
            }
        }

        private void CarregarTaxas(List<Taxas> taxas)
        {
            listTaxas.Items.Clear();

            foreach (var item in taxas)
            {
                listTaxas.Items.Add(item);
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            locacao.Funcionario = (Funcionario)cmbFuncionario.SelectedItem;
            locacao.Cliente = (Cliente)cmbCliente.SelectedItem;
            locacao.Condutor = (Condutor)cmbCondutor.SelectedItem;
            //locacao.Veiculo = (Veiculo)cmbVeiculo.SelectedItem;
            locacao.PlanoDeCobranca = (PlanoDeCobranca)cmbPlanoDeCobranca.SelectedItem;
            locacao.Taxas = taxas;
            locacao.DataLocacao = dtpDataDeLocacao.Value;
            locacao.DataDevolucaoPrevista = dtpDevolucaoPrevista.Value;
            locacao.ValorTotalPrevisto = Convert.ToDecimal(txtValorTotalPrevisto.Text);
        }

        /*
        private void CarregarVeiculos(List<Veiculo> veiculos) -- esperando merge de modulo veiculo
        {
            cmbVeiculo.Items.Clear();

            foreach (var item in veiculos)
            {
                cbVeiculo.Items.Add(item);
            }
        }
        */

    }
}