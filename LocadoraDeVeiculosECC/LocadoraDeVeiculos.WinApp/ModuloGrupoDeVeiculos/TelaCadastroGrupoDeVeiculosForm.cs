﻿using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
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

namespace LocadoraDeVeiculos.WinApp.ModuloGrupoDeVeiculos
{
    public partial class TelaCadastroGrupoDeVeiculosForm : Form
    {
        private GrupoDeVeiculos gruposDeVeiculos;
        public Func<GrupoDeVeiculos, Result<GrupoDeVeiculos>> GravarRegistro { get; set; }
        public TelaCadastroGrupoDeVeiculosForm()
        {
            InitializeComponent();
        }
        public GrupoDeVeiculos GruposDeVeiculos
        {
            get { return gruposDeVeiculos; }
            set
            {
                gruposDeVeiculos = value;

                txtNomeDogrupo.Text = gruposDeVeiculos.NomeDoGrupo;

            }
        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            gruposDeVeiculos.NomeDoGrupo = txtNomeDogrupo.Text;

        }
        private void TelaCadastroFuncionarioForm_Load(object sender, EventArgs e)
        {
            TelaMenuPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroFuncionarioForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaMenuPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void buttonGravar_Click_1(object sender, EventArgs e)
        {
            gruposDeVeiculos.NomeDoGrupo = txtNomeDogrupo.Text;


            var resultadoValidacao = GravarRegistro(GruposDeVeiculos);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção de Grupo De Veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaMenuPrincipalForm.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
        }
    }
}
