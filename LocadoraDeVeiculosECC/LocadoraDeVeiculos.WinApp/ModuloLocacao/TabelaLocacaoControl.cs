using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.WinApp.Compartilhado;
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
    public partial class TabelaLocacaoControl : UserControl
    {
        public TabelaLocacaoControl()
        {
            InitializeComponent();
            Grid.ConfigurarGridZebrado();
            Grid.ConfigurarGridSomenteLeitura();
            Grid.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Funcionario", HeaderText = "Funcionário"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Cliente", HeaderText = "Cliente"},

              //  new DataGridViewTextBoxColumn { DataPropertyName = "Veiculo", HeaderText = "Veículo"}, -- Esperando dar merge 

                new DataGridViewTextBoxColumn { DataPropertyName = "Condutor", HeaderText = "Condutor"},

                new DataGridViewTextBoxColumn { DataPropertyName = "PlanoDeCobranca", HeaderText = "Plano De Cobranca"},

                new DataGridViewTextBoxColumn { DataPropertyName = "DataLocacao", HeaderText = "Dada Locação"},

                new DataGridViewTextBoxColumn { DataPropertyName = "DataDevolucaoPrevista", HeaderText = "Data Devolução Prevista"},

                new DataGridViewTextBoxColumn { DataPropertyName = "ValorTotalPrevisto", HeaderText = "Valor Total Previsto"},

            };
            return colunas;
        }

        internal void AtualizarRegistros(List<Locacao> locacoes)
        {
            Grid.Rows.Clear();

            foreach (var locacao in locacoes)
            {
                Grid.Rows.Add(locacao.Id, locacao.Funcionario.Nome, locacao.Cliente.Nome, /*locacao.Veiculo.Marca*/ locacao.Condutor.Nome, locacao.PlanoDeCobranca.TipoDePlano, locacao.DataLocacao, locacao.DataDevolucaoPrevista, locacao.ValorTotalPrevisto);
            }
        }


        public Guid ObtemIdLocacaoSelecionado()
        {
            return Grid.SelecionarNumero<Guid>();
        }


    }
}
