using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
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

namespace LocadoraDeVeiculos.WinApp.ModuloLocacao
{
    public partial class TelaCadastroLocacaoForm : Form
    {
        private Locacao locacao = new Locacao();
        List<Taxas> taxas = new List<Taxas>();
        
       
        public TelaCadastroLocacaoForm(List<Funcionario> funcionarios,List<Cliente> clientes, List<Condutor> condutores, /*List<Veiculo> veiculos,*/ List<PlanoDeCobranca> planos, List<Taxas> taxas)
        {
            InitializeComponent();
            this.ConfigurarTela();

            dtpDevolucaoPrevista.MaxDate = DateTime.Today.Date.AddDays(30);
            dtpDevolucaoPrevista.MinDate = DateTime.Today;
            dtpDataDeLocacao.MinDate = DateTime.Today;

            
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
                        cbTaxas.Items.Add(item);
                    }
                }


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
            cbTaxas.Items.Clear();

            foreach (var item in taxas)
            {
                cbTaxas.Items.Add(item);
            }
        }

        private void CarregarTaxasNaLocacao()
        {
            locacao.Taxas.Clear();


            var taxasChecked = new List<Taxas>();

            foreach (var item in cbTaxas.CheckedItems)
            {
                taxasChecked.Add((Taxas)item);
                
            }


            locacao.Taxas = taxasChecked;

            foreach (var item in taxasChecked)
            {
                locacao.ValorTotalPrevisto = locacao.ValorTotalPrevisto + item.Valor;
            }


            
            txtValorTotalPrevisto.Text = locacao.ValorTotalPrevisto.ToString();
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

            //locacao.ValorTotalPrevisto = Convert.ToDecimal(txtValorTotalPrevisto.ToString());
            locacao.ValorTotalPrevisto = CalculaValorLocacao();
            CarregarTaxasNaLocacao();
            var resultadoValidacao = GravarRegistro(locacao);
            
           
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

        private void cbTaxas_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        

        private void cbCondutorCliente_CheckedChanged(object sender, EventArgs e)
        {
            cmbCliente.Items.Clear();
            if(cbCondutorCliente.Checked == true)
            {
               Condutor condutor =  PegarCondutor();
              
                
                cmbCliente.Items.Add(condutor.Cliente);
            }
            
        }

        private Condutor PegarCondutor()
        {
            var condutorSelecionado = (Condutor)cmbCondutor.SelectedItem;
            return condutorSelecionado;
        }

        private void btnAtualizarValor_Click(object sender, EventArgs e)
        {
            if (CalculaValorLocacao() == -1)
            {
                TelaMenuPrincipalForm.Instancia.AtualizarRodape("'Plano' não deve ser nulo");
                DialogResult = DialogResult.None;
                return;
            }
            txtValorTotalPrevisto.Text = "R$ " + CalculaValorLocacao();

        }

        private decimal CalculaValorLocacao()
        {
            TimeSpan aluguel = (dtpDevolucaoPrevista.Value.Date.Subtract(dtpDataDeLocacao.Value.Date));
            int dias = Convert.ToInt32(aluguel.Days);

            decimal valorTaxas = 0;

            if (cmbPlanoDeCobranca.SelectedItem == null)
            {
                return -1;
            }

            decimal valorDiaria = ((PlanoDeCobranca)cmbPlanoDeCobranca.SelectedItem).ValorDiario;


            foreach (var item in taxas)
            {
                valorTaxas = +item.Valor;
            }

            return valorTaxas + (dias * valorDiaria);
        }


        private void cmbCondutor_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCliente.Items.Clear();
           
            Condutor condutor = PegarCondutor();
            cmbCliente.Items.Add(condutor.Cliente);
            cmbCliente.SelectedItem = condutor.Cliente;
            
        }
    }
}
