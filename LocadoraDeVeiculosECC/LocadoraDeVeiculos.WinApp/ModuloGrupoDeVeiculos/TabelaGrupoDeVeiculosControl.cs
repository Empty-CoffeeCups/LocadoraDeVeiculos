using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
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

namespace LocadoraDeVeiculos.WinApp.ModuloGrupoDeVeiculos
{
    public partial class TabelaGrupoDeVeiculosControl : UserControl
    {
        public TabelaGrupoDeVeiculosControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "NomeDoGrupo", HeaderText = "Nome"},

           };

            return colunas;
        }

        internal void AtualizarRegistros(List<GrupoDeVeiculos> gruposDeVeiculos)
        {
            grid.Rows.Clear();

            foreach (GrupoDeVeiculos grupoDeVeiculo in gruposDeVeiculos)
            {
                grid.Rows.Add(grupoDeVeiculo.Id, grupoDeVeiculo.NomeDoGrupo);
            }
        }

        internal Guid ObtemIdGrupoDeVeiculosSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
        }
    }
}
