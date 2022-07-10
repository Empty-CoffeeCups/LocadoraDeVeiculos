using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
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

namespace LocadoraDeVeiculos.WinApp.ModuloPlanoDeCobranca
{
    public partial class TelaCadastroPlanoDeCobranca : Form
    {
        private PlanoDeCobranca plano;
        

        public TelaCadastroPlanoDeCobranca(List<GrupoDeVeiculos> grupos)
        {
            InitializeComponent();
            this.ConfigurarTela();
            CarregarGrupos(grupos);
            ConfigInicialDaTela();
        }

        public PlanoDeCobranca Plano
        {
            get { return plano; }
            set
            {
                plano = value;
                cbGrupoDeVeiculo.SelectedItem = plano.GrupoDeVeiculo;
                cbTipoDePlano.SelectedItem = plano.TipoDePlano;

                txtDiario.Text = plano.ValorDiario.ToString();
                txtKmIncluso.Text = plano.ValorKmIncluso.ToString();
                txtKmRodado.Text = plano.PrecoKmRodado.ToString();

            }
        }

        private void CarregarGrupos(List<GrupoDeVeiculos> grupos)
        {
            cbGrupoDeVeiculo.Items.Clear();

            foreach (var item in grupos)
            {
                cbGrupoDeVeiculo.Items.Add(item);
            }
        }

        public Func<PlanoDeCobranca, ValidationResult> GravarRegistro { get; set; }





        //Métodos Privados

        private void btnGravar_Click(object sender, EventArgs e)
        {
            plano.GrupoDeVeiculo = (GrupoDeVeiculos)cbGrupoDeVeiculo.SelectedItem;
            plano.TipoDePlano = (TipoDePlano)cbTipoDePlano.SelectedItem;
            plano.ValorDiario = Convert.ToDecimal(txtDiario);
            plano.ValorKmIncluso = Convert.ToDecimal(txtKmIncluso);
            plano.PrecoKmRodado = Convert.ToDecimal(txtKmRodado);


            var resultadoValidacao = GravarRegistro(plano);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaMenuPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }



        private void cbTipoDePlano_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoDePlano.SelectedItem.Equals(TipoDePlano.Diario))
            {
                txtDiario.Clear();
                txtKmIncluso.Clear();
                txtKmRodado.Clear();

                txtKmIncluso.Text = "0";
                txtKmIncluso.Enabled = false;

                txtDiario.Enabled = true;
                txtKmRodado.Enabled = true;
            }
            else if (cbTipoDePlano.SelectedItem.Equals(TipoDePlano.Controlado))
            {
                txtDiario.Clear();
                txtKmIncluso.Clear();
                txtKmRodado.Clear();

                txtDiario.Enabled = true;
                txtKmIncluso.Enabled = true;
                txtKmRodado.Enabled = true;

            }
            else if (cbTipoDePlano.SelectedItem.Equals(TipoDePlano.Livre))
            {
                txtDiario.Clear();
                txtKmIncluso.Clear();
                txtKmRodado.Clear();

                txtKmIncluso.Text = "0";
                txtKmIncluso.Enabled = false;
                txtKmRodado.Text = "0";
                txtKmRodado.Enabled = false;

                txtDiario.Enabled = true;
            }
        }

        private void ConfigInicialDaTela()
        {
            cbTipoDePlano.Enabled = false;
            txtDiario.Enabled = false;
            txtKmIncluso.Enabled = false;
            txtKmRodado.Enabled = false;
        }

        private void cbGrupoDeVeiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTipoDePlano.Enabled = true;
        }

        private void TelaCadastroPlanoDeCobrancaForm_Load(object sender, EventArgs e)
        {
            TelaMenuPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroPlanoDeCobrancaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaMenuPrincipalForm.Instancia.AtualizarRodape("");
        }

    }
}
