using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloGrupoDeVeiculos
{
    public class ControladorGrupoDeVeiculos
    {
        private readonly IRepositorioGrupoDeVeiculos repositorioGrupoDeVeiculos;
        private TabelaGrupoDeVeiculosControl tabelaGruposDeFuncionarios;

        public ControladorGrupoDeVeiculos(IRepositorioGrupoDeVeiculos repositorio)
        {
            this.repositorioGrupoDeVeiculos = repositorio;
        }

        public void Inserir()
        {
            TelaCadastroGrupoDeVeiculosForm tela = new TelaCadastroGrupoDeVeiculosForm();
            tela.GruposDeVeiculos = new GrupoDeVeiculos();

            tela.GravarRegistro = repositorioGrupoDeVeiculos.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarGrupoDeVeiculos();
            }
        }

        public void Editar()
        {
            GrupoDeVeiculos grupoDeVeiculosSelecionado = ObtemGrupoDeVeiculosSelecionado();

            if (grupoDeVeiculosSelecionado == null)
            {
                MessageBox.Show("Selecione uma grupo de veiculo primeiro",
                "Edição de grupo de veiculos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroGrupoDeVeiculosForm tela = new TelaCadastroGrupoDeVeiculosForm();

            tela.GruposDeVeiculos = grupoDeVeiculosSelecionado;

            tela.GravarRegistro = repositorioGrupoDeVeiculos.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarGrupoDeVeiculos();
            }


        }

        public void Excluir()
        {
            GrupoDeVeiculos grupoDeVeiculosSelecionado = ObtemGrupoDeVeiculosSelecionado();

            if (grupoDeVeiculosSelecionado == null)
            {
                MessageBox.Show("Selecione um grupo de veiculo",
                "Exclusão de grupo de veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Grupo de veiculo?",
                "Exclusão de Grupo de Veiculo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioGrupoDeVeiculos.Excluir(grupoDeVeiculosSelecionado);
                CarregarGrupoDeVeiculos();
            }
        }

        public UserControl ObtemListagem()
        {

            tabelaGruposDeVeiculos = new TabelaGrupoDeVeiculosControl();

            CarregarGrupoDeVeiculos();

            return tabelaGruposDeVeiculos;
        }


        public ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxFuncionario();
        }


        private GrupoDeVeiculos ObtemGrupoDeVeiculosSelecionado()
        {
            var Id = tabelaFuncionarios.ObtemNumeroTaxaSelecionada();

            return repositorioFuncionarios.SelecionarPorId(Id);
        }

        private void CarregarGrupoDeVeiculos()
        {
            List<GrupoDeVeiculos> grupoDeVeiculos = repositorioGrupoDeVeiculos.SelecionarTodos();

            tabelaFuncionarios.AtualizarRegistros(grupoDeVeiculos);

        }
    }
}
