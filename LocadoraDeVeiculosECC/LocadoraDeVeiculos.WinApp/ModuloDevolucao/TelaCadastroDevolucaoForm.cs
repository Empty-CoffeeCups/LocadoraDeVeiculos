using FluentResults;
using LocadoraDeVeiculos.Aplicacao.ModuloLocacao;
using LocadoraDeVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
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

namespace LocadoraDeVeiculos.WinApp.ModuloDevolucao
{
    public partial class TelaCadastroDevolucaoForm : Form
    {
        private decimal valorFinal = 0;
        public Devolucao devolucao;
        private ServicoLocacao servicoLocacao;
        private ServicoTaxa servicoTaxa;
        private ServicoPlanoDeCobranca servicoPlanoDeCobranca;

       
        List<Taxas> taxas;
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

            decimal valorTotal = calcularValorFinal();
            devolucao.ValorTotal =  valorTotal;
            devolucao.NivelDoTanque = ObterValorNivelTanque();

            if (devolucao.DataDeDevolucao > devolucao.Locacao.DataDevolucaoPrevista)
            {
                devolucao.ValorTotal += AdicionarCobrancaAtraso();
            }


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

                cmbLocacao.Items.Add(locacao.Cliente.Nome);

            }
        }

        private void cmbLocacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTaxasLocacao.Items.Clear();
            List<Taxas> taxasReseta = new List<Taxas>();

            taxas = taxasReseta;

            foreach (var item in locacoes)
            {

               if (item.Cliente.Nome.Equals(cmbLocacao.SelectedItem))
                {
                    devolucao.Locacao = item;
                    taxas = item.Taxas;
                }

              

            }


            foreach (var item in taxas)
            {
                cbTaxasLocacao.Items.Add(item);
                cbTaxasLocacao.Enabled = false;
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

        

        private decimal calcularValorFinal()
        {

            decimal valorConvertido = Convert.ToDecimal(txtValorTotal.Text);


            /*
            if (cbLavagem.Checked == true)
            {
                valorFinal = valorFinal + 50;
                valorFinal = valorFinal + devolucao.Locacao.ValorTotalPrevisto;
                txtValorTotal.Text = valorFinal.ToString();
            }

           if(cbTranslado.Checked == true)
            {
                valorFinal = valorFinal + 100;
                valorFinal = valorFinal + devolucao.Locacao.ValorTotalPrevisto;
                txtValorTotal.Text = valorFinal.ToString();
            }

            if (cbManutencao.Checked == true)
            {
                valorFinal = valorFinal + 150;
                valorFinal = valorFinal + devolucao.Locacao.ValorTotalPrevisto;
                txtValorTotal.Text = valorFinal.ToString();
            }
            */
            
            return valorConvertido;
        }

       
        //Events

        private void cbLavagem_CheckedChanged(object sender, EventArgs e)
        {
            

            if (cbLavagem.Checked == true)
            {
                valorFinal = 0;
                valorFinal = valorFinal + 50;
                valorFinal += devolucao.Locacao.ValorTotalPrevisto;

                if(cbManutencao.Checked == true)
                {
                    valorFinal += 150;
                }

                if (cbTranslado.Checked == true)
                {
                    valorFinal += 100;
                }


            }
            else if(cbLavagem.Checked != true)
            {

                valorFinal = valorFinal - 50;

            }

            
            txtValorTotal.Text = valorFinal.ToString();

        }

        private void cbManutencao_CheckedChanged(object sender, EventArgs e)
        {
            if (cbManutencao.Checked == true)
            {
                valorFinal = 0;
                valorFinal = valorFinal + 150;
                valorFinal += devolucao.Locacao.ValorTotalPrevisto;

            }

            if(cbLavagem.Checked == true)
            {
                valorFinal += 50;
            }
            if (cbTranslado.Checked == true)
            {
                valorFinal += 100;
            }

            else if (cbManutencao.Checked != true)
            {

                valorFinal = valorFinal - 150;

            }


            txtValorTotal.Text = valorFinal.ToString();
        }

        private void cbTranslado_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTranslado.Checked == true)
            {
                valorFinal = 0;
                valorFinal = valorFinal + 100;
                valorFinal += devolucao.Locacao.ValorTotalPrevisto;

            }

            if(cbLavagem.Checked == true)
            {
                valorFinal += 50;
            }

            if(cbManutencao.Checked == true)
            {
                valorFinal += 150;
            }

            else if (cbTranslado.Checked != true)
            {

                valorFinal = valorFinal - 100;

            }


            txtValorTotal.Text = valorFinal.ToString();
        }


        private Decimal ObterValorNivelTanque()
        {
            Decimal valorNivel = 0;

            if (cmbNivelDoTanque.SelectedItem == "Vazio")
            {
                valorNivel = 1;
                devolucao.ValorTotal += 200;
                
            }

            if (cmbNivelDoTanque.SelectedItem == "1/4")
            {
                valorNivel = 25;
                devolucao.ValorTotal += 150;
               
            }

            if (cmbNivelDoTanque.SelectedItem == "1/2")
            {
                valorNivel = 50;
                devolucao.ValorTotal += 100;

            }

            if (cmbNivelDoTanque.SelectedItem == "3/4")
            {
                valorNivel = 75;
                devolucao.ValorTotal += 50;

            }

            if (cmbNivelDoTanque.SelectedItem == "Cheio")
            {
                valorNivel = 100;
            }

            return valorNivel;
        }

        private void cmbNivelDoTanque_SelectedIndexChanged(object sender, EventArgs e)
        {
            devolucao.NivelDoTanque = cmbNivelDoTanque.SelectedIndex;
        }

        private Decimal AdicionarCobrancaAtraso()
        {
           decimal valorTaxaAdicional =  devolucao.ValorTotal / 10;

            return valorTaxaAdicional;

        }
    }
}
