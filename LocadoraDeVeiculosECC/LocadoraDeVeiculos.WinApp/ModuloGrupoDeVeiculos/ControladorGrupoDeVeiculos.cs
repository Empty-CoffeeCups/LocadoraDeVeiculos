using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloGrupoDeVeiculos
{
    public class ControladorGrupoDeVeiculos : ControladorBase
    {
        private readonly IRepositorioGrupoDeVeiculos repositorioGrupoVeiculos;
        private TabelaGrupoDeVeiculosControl listagemGrupoVeiculos;
        private readonly ServicoGrupoDeVeiculos servicoGrupoVeiculo;

        public ControladorGrupoDeVeiculos(IRepositorioGrupoDeVeiculos repositorioGrupoVeiculos,
            ServicoGrupoDeVeiculos servicoGrupoVeiculo)
        {
            this.repositorioGrupoVeiculos = repositorioGrupoVeiculos;
            this.servicoGrupoVeiculo = servicoGrupoVeiculo;
        }

        public override void Inserir()
        {
            var tela = new TelaCadastroGrupoDeVeiculosForm();
            tela.GruposDeVeiculos = new GrupoDeVeiculos();
            tela.GravarRegistro = servicoGrupoVeiculo.Inserir;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
                CarregarGrupos();
        }

        public override void Editar()
        {
            GrupoDeVeiculos grupoVeiculosSelecionado = ObtemGrupoVeiculosSelecionado();

            if (grupoVeiculosSelecionado == null)
            {
                MessageBox.Show("Selecione um grupo de veículos primeiro",
                "Edição de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var tela = new TelaCadastroGrupoDeVeiculosForm();

            tela.GruposDeVeiculos = grupoVeiculosSelecionado;

            tela.GravarRegistro = servicoGrupoVeiculo.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarGrupos();
        }

        public override void Excluir()
        {
            GrupoDeVeiculos grupoVeiculosSelecionado = ObtemGrupoVeiculosSelecionado();

            if (grupoVeiculosSelecionado == null)
            {
                MessageBox.Show("Selecione um grupo de veículos primeiro",
                "Exclusão de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o grupo de veículos?",
            "Exclusão de Grupo de Veículos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioGrupoVeiculos.Excluir(grupoVeiculosSelecionado);
                CarregarGrupos();
            }
        }

        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxGrupoDeVeiculos();
        }

        public override UserControl ObtemListagem()
        {
            if (listagemGrupoVeiculos == null)
                listagemGrupoVeiculos = new TabelaGrupoDeVeiculosControl();

            CarregarGrupos();

            return listagemGrupoVeiculos;
        }

        #region MÉTODOS PRIVADOS

        private void CarregarGrupos()
        {
            List<GrupoDeVeiculos> grupos = repositorioGrupoVeiculos.SelecionarTodos();

            listagemGrupoVeiculos.AtualizarRegistros(grupos);

            TelaMenuPrincipalForm.Instancia.AtualizarRodape($"Visualizando {grupos.Count} grupo(s) de veículos");
        }

        private GrupoDeVeiculos ObtemGrupoVeiculosSelecionado()
        {
            var id = listagemGrupoVeiculos.ObtemIdGrupoDeVeiculosSelecionado();

            return repositorioGrupoVeiculos.SelecionarPorId(id);
        }

        #endregion
    }
}
