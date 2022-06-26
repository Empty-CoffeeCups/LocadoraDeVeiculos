﻿using FluentValidation.Results;
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

namespace LocadoraDeVeiculos.WinApp.ModuloTaxas
{
    public partial class TelaCadastroTaxasForm : Form
    {
        public TelaCadastroTaxasForm()
        {
            InitializeComponent();
        }

        private Taxas taxas;

        public Func<Taxas, ValidationResult> GravarRegistro { get; set; }

        public Taxas Taxas
        {
            get { return taxas; }
            set
            {
                taxas = value;

                txtNumero.Text = taxas.Id.ToString();
                txtDescricao.Text = taxas.Descricao;
                txtValor.Text = taxas.Valor.ToString();

            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            taxas.Descricao = txtDescricao.Text;
            // TODO: Tratar se houver formatações futuras na tela.
            taxas.Valor = Convert.ToDecimal(txtValor.Text);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }


        private void TelaCadastroTaxasForm_Load(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroTaxasForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        
    }
}
