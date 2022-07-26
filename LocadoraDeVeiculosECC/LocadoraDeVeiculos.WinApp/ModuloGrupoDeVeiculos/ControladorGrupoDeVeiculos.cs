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
        
        private TabelaGrupoDeVeiculosControl listagemGrupoDeVeiculos;
        private readonly ServicoGrupoDeVeiculos servicoGrupoDeVeiculos;

        public ControladorGrupoDeVeiculos(ServicoGrupoDeVeiculos servicoGrupoDeVeiculos)
        {
            this.servicoGrupoDeVeiculos = servicoGrupoDeVeiculos;
        }

        public override void Inserir()
        {
            var tela = new TelaCadastroGrupoDeVeiculosForm();

            tela.GruposDeVeiculos = new GrupoDeVeiculos();

            tela.GravarRegistro = servicoGrupoDeVeiculos.Inserir;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarGrupoDeVeiculos();
            }
        }

        public override void Editar()
        {
            var id = listagemGrupoDeVeiculos.ObtemIdGrupoDeVeiculosSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um Grupo De Veiculos primeiro",
                    "Edição de Grupo De Veiculos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoGrupoDeVeiculos.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Grupo De Veiculos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var funcionarioSelecionado = resultado.Value;

            var tela = new TelaCadastroGrupoDeVeiculosForm();

            tela.GruposDeVeiculos = funcionarioSelecionado.Clone();

            tela.GravarRegistro = servicoGrupoDeVeiculos.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarGrupoDeVeiculos();

        }

        public override void Excluir()
        {
            var id = listagemGrupoDeVeiculos.ObtemIdGrupoDeVeiculosSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um Grupo De Veiculos primeiro",
                    "Exclusão de Grupo De Veiculos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoGrupoDeVeiculos.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Grupo De Veiculos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var grupoDeVeiculosSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o Grupo De Veiculos?", "Exclusão de Grupo De Veiculos",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoGrupoDeVeiculos.Excluir(grupoDeVeiculosSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarGrupoDeVeiculos();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Grupo De Veiculos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxGrupoDeVeiculos();
        }

        public override UserControl ObtemListagem()
        {
            if (listagemGrupoDeVeiculos == null)
                listagemGrupoDeVeiculos = new TabelaGrupoDeVeiculosControl();

            CarregarGrupoDeVeiculos();

            return listagemGrupoDeVeiculos;
        }

        #region MÉTODOS PRIVADOS

        private void CarregarGrupoDeVeiculos()
        {
            var resultado = servicoGrupoDeVeiculos.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<GrupoDeVeiculos> grupoDeVeiculos = resultado.Value;

                listagemGrupoDeVeiculos.AtualizarRegistros(grupoDeVeiculos);

                TelaMenuPrincipalForm.Instancia.AtualizarRodape($"Visualizando {grupoDeVeiculos.Count} Grupo(s) De Veiculos");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Grupo De Veiculos",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
