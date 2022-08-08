using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
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

namespace LocadoraDeVeiculos.WinApp.ModuloDevolucao
{
    public partial class TabelaDevolucaoControl : UserControl
    {
        public TabelaDevolucaoControl()
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número"},

                new DataGridViewTextBoxColumn { DataPropertyName = "LocacaoId", HeaderText = "Locação"},

                new DataGridViewTextBoxColumn { DataPropertyName = "KmVeiculo", HeaderText = "Quilometragem"},

                new DataGridViewTextBoxColumn { DataPropertyName = "DataDeDevolucao", HeaderText = "Data de Devolução"},

                new DataGridViewTextBoxColumn { DataPropertyName = "NivelDoTanque", HeaderText = "Nível do Tanque"},

                new DataGridViewTextBoxColumn { DataPropertyName = "PlanoDeCobranca", HeaderText = "Plano De Cobranca"},

                new DataGridViewTextBoxColumn { DataPropertyName = "ValorTotal", HeaderText = "Valor Total"},

            };
            return colunas;
        }

        public void AtualizarRegistros(List<Devolucao> devolucoes)
        {
            grid.Rows.Clear();

            foreach (Devolucao devolucao in devolucoes)
            {
                grid.Rows.Add(devolucao.Id, devolucao.Locacao.Id, devolucao.KmVeiculo, devolucao.DataDeDevolucao.ToShortDateString(), devolucao.NivelDoTanque + "% ", devolucao.Locacao.PlanoDeCobranca.TipoDePlano, devolucao.ValorTotal);

            }

        }

        public Guid ObtemIdDevolucaoSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
        }
    }
}
