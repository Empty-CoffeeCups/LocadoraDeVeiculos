using locadoraDeVeiculos.Infra.ModuloFuncionario;
using locadoraDeVeiculos.Infra.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloPlanoDeCobranca
{
    public class ControladorPlanoDeCobranca : ControladorBase
    {
       
        
        private TabelaPlanoDeCobrancaControl listagemPlanos;
        private readonly ServicoPlanoDeCobranca servicoPlanoDeCobranca;
        private readonly ServicoGrupoDeVeiculos servicoGrupoDeVeiculos;

        public ControladorPlanoDeCobranca(ServicoPlanoDeCobranca servicoPlanoDeCobranca, ServicoGrupoDeVeiculos servicoGrupoDeVeiculos)
        {
            this.servicoPlanoDeCobranca = servicoPlanoDeCobranca;
            this.servicoGrupoDeVeiculos = servicoGrupoDeVeiculos;
        }

        public override void Inserir()
        {
            var grupos = servicoGrupoDeVeiculos.SelecionarTodos().Value;

            var tela = new TelaCadastroPlanoDeCobranca(grupos);

            tela.Plano = new PlanoDeCobranca();

            tela.GravarRegistro = servicoPlanoDeCobranca.Inserir;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarPlanoDeCobranca();
            }
        }

        public override void Editar()
        {
            var id = listagemPlanos.ObtemNumeroPlanoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um plano primeiro",
                    "Edição de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoPlanoDeCobranca.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var planoSelecionado = resultado.Value;

            var grupos = servicoGrupoDeVeiculos.SelecionarTodos().Value;

            var tela = new TelaCadastroPlanoDeCobranca(grupos);

            tela.Plano = planoSelecionado.Clonar();

            tela.GravarRegistro = servicoPlanoDeCobranca.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarPlanoDeCobranca();
        }

        public override void Excluir()
        {
            var id = listagemPlanos.ObtemNumeroPlanoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um plano primeiro",
                    "Exclusão de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoPlanoDeCobranca.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Plano de Cobraça", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var planoSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o plano?", "Exclusão de Plano de Cobrança",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoPlanoDeCobranca.Excluir(planoSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarPlanoDeCobranca();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Plano", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public override UserControl ObtemListagem()
        {
            listagemPlanos= new TabelaPlanoDeCobrancaControl();

            CarregarPlanoDeCobranca();

            return listagemPlanos;
        }

        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxPlanoDeCobranca();
        }


        //Métodos Privados

        private void CarregarPlanoDeCobranca()
        {
            var resultado = servicoPlanoDeCobranca.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<PlanoDeCobranca> planos = resultado.Value;

                listagemPlanos.AtualizarRegistros(planos);

                TelaMenuPrincipalForm.Instancia.AtualizarRodape($"Visualizando {planos.Count} plano(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Plano de Cobrança",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
