using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
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

namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    public partial class TabelaFuncionarioControl : UserControl
    {
        public TabelaFuncionarioControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                 new DataGridViewTextBoxColumn { DataPropertyName = "Usuario", HeaderText = "Usuario"},
                                  
               new DataGridViewTextBoxColumn { DataPropertyName = "Senha", HeaderText = "Senha"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Salario", HeaderText = "Salario"},

                 new DataGridViewTextBoxColumn { DataPropertyName = "Admin", HeaderText = "Adimn"},
           };

            return colunas;
        }

        internal void AtualizarRegistros(List<Funcionario> funcionarios)
        {
            grid.Rows.Clear();

            foreach (Funcionario funcionario in funcionarios)
            {
                grid.Rows.Add(funcionario.Id, funcionario.Nome, funcionario.Usuario, funcionario.Senha, funcionario.Salario, funcionario.Admin); 
            }
        }

        internal int ObtemNumeroTaxaSelecionada()
        {
            return grid.SelecionarNumero<int>();
        }
    }
}
