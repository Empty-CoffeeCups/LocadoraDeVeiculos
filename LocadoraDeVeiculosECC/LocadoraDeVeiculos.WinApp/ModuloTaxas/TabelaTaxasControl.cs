using LocadoraDeVeiculos.Dominio.ModuloTaxas;
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

namespace LocadoraDeVeiculos.WinApp.ModuloTaxas
{
    public partial class TabelaTaxasControl : UserControl
    {
        public TabelaTaxasControl()
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Número"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Descricao", HeaderText = "Descrição"},

                 new DataGridViewTextBoxColumn { DataPropertyName = "Valor", HeaderText = "Valor"},
           };

            return colunas;
        }

        internal void AtualizarRegistros(List<Taxas> taxas)
        {
            grid.Rows.Clear();

            foreach (Taxas taxa in taxas)
            {
                grid.Rows.Add(taxa.Id, taxa.Descricao, taxa.Valor);
            }
        }

        internal int ObtemNumeroTaxaSelecionada()
        {
            return grid.SelecionarNumero<int>();
        }
    }
}
