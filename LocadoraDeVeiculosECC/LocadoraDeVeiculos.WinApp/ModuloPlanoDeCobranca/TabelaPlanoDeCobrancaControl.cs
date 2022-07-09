using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
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

namespace LocadoraDeVeiculos.WinApp.ModuloPlanoDeCobranca
{
    public partial class TabelaPlanoDeCobrancaControl : UserControl
    {
        public TabelaPlanoDeCobrancaControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "TipoDePlano", HeaderText = "Plano"},

                new DataGridViewTextBoxColumn { DataPropertyName = "ValorDiario", HeaderText = "Diária"},

                new DataGridViewTextBoxColumn { DataPropertyName = "ValorKmIncluso", HeaderText = "KM Incluso"},

                new DataGridViewTextBoxColumn { DataPropertyName = "PrecoKmRodado", HeaderText = "Preço/KM Rodado"},

                new DataGridViewTextBoxColumn { DataPropertyName = "GrupoDeVeiculo", HeaderText = "Grupo"},

            };

            return colunas;
        }


        internal void AtualizarRegistros(List<PlanoDeCobranca> planos)
        {
            grid.Rows.Clear();

            foreach (var planoDeCobranca in planos)
            {
                grid.Rows.Add(planoDeCobranca.Id,
                    planoDeCobranca.TipoDePlano,
                    planoDeCobranca.ValorDiario,
                    planoDeCobranca.ValorKmIncluso,
                    planoDeCobranca.PrecoKmRodado,
                    planoDeCobranca.GrupoDeVeiculo);
            }
        }


        public int ObtemNumeroPlanoSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }




    }
}
