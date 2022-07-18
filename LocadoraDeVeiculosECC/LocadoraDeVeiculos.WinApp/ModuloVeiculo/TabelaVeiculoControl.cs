using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
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

namespace LocadoraDeVeiculos.WinApp.ModuloVeiculo
{
    public partial class TabelaVeiculoControl : UserControl
    {
        public TabelaVeiculoControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "GruposDeVeiculos", HeaderText = " Grupos De Veiculos"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Modelo", HeaderText = "Modelo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Marca", HeaderText = "Marca"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Placa", HeaderText = "Placa"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Cor", HeaderText = "Cor"},

                new DataGridViewTextBoxColumn { DataPropertyName = "TipoDeCombustivel", HeaderText = "Tipo De Combustivel"},

                new DataGridViewTextBoxColumn { DataPropertyName = "CapacidadeDoTanque", HeaderText = "Capacidade Do Tanque"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Ano", HeaderText = "Ano"},

                new DataGridViewTextBoxColumn { DataPropertyName = "KmPercorrido", HeaderText = "Km Percorrido"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Foto", HeaderText = "Foto"},

            };

            return colunas;
        }

        internal void AtualizarRegistros(List<Veiculo> veiculos)
        {
            grid.Rows.Clear();

            foreach (var veiculo in veiculos)
            {
                grid.Rows.Add(veiculo.Id,
                    veiculo.GruposDeVeiculos,
                    veiculo.Modelo,
                    veiculo.Marca,
                    veiculo.Placa,
                    veiculo.Cor,
                    veiculo.TipoDeCombustivel,
                    veiculo.CapacidadeDoTanque,
                    veiculo.Ano,
                    veiculo.KmPercorrido,
                    veiculo.Foto
                    );
            }
        }
        public Guid ObtemNumeroVeiculoSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
        }
    }
}
