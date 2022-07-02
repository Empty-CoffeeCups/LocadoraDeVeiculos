using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
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
                txtDescricao.Text = taxas.Descricao;
                numericValor.Value = taxas.Valor;
                if (taxas.TipoCalculo == 0)
                    radioButtonDiario.Checked = true;
                else radioButtonFixo.Checked = true;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            taxas.Descricao = txtDescricao.Text;
            taxas.Valor = numericValor.Value;
            taxas.TipoCalculo = (TipoCalculo)(radioButtonDiario.Checked == true ? 0 : 1);

            var resultadoValidacao = GravarRegistro(taxas);
            

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaMenuPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }


        private void TelaCadastroTaxasForm_Load(object sender, EventArgs e)
        {
            TelaMenuPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroTaxasForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaMenuPrincipalForm.Instancia.AtualizarRodape("");
        }

        
    }
}
