using locadoraDeVeiculos.Infra.ModuloFuncionario;
using locadoraDeVeiculos.Infra.ModuloPlanoDeCobranca;
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
        private readonly RepositorioPlanoDeCobrancaEmBancoDados repositorioPlanoDeCobranca;
        private readonly RepositorioGrupoDeVeiculosEmBancoDados repositorioGrupoDeVeiculos = new RepositorioGrupoDeVeiculosEmBancoDados();
        private TabelaPlanoDeCobrancaControl listagemPlanos;
        private readonly ServicoPlanoDeCobranca servicoPlanoDeCobranca;

        public ControladorPlanoDeCobranca(RepositorioPlanoDeCobrancaEmBancoDados repositorioPlanoDeCobranca, ServicoPlanoDeCobranca servicoPlanoDeCobranca)
        {
            this.repositorioPlanoDeCobranca = repositorioPlanoDeCobranca;
            this.servicoPlanoDeCobranca = servicoPlanoDeCobranca;
        }

        public override void Inserir()
        {
            var grupos = repositorioGrupoDeVeiculos.SelecionarTodos();

            TelaCadastroPlanoDeCobranca tela = new TelaCadastroPlanoDeCobranca(grupos);
            tela.Plano = new PlanoDeCobranca();

            tela.GravarRegistro = servicoPlanoDeCobranca.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarPlanos();
            }
        }

        public override void Editar()
        {
            PlanoDeCobranca planoSelecionado = ObtemPlanoSelecionado();

            if (planoSelecionado == null)
            {
                MessageBox.Show("Selecione um plano primeiro",
                "Edição de Planos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var grupos = repositorioGrupoDeVeiculos.SelecionarTodos();

            TelaCadastroPlanoDeCobranca tela = new TelaCadastroPlanoDeCobranca(grupos);

            tela.Plano = planoSelecionado.Clonar();

            tela.GravarRegistro = servicoPlanoDeCobranca.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarPlanos();
            }
        }

        public override void Excluir()
        {
            PlanoDeCobranca planoSelecionado = ObtemPlanoSelecionado();

            if (planoSelecionado == null)
            {
                MessageBox.Show("Selecione um plano primeiro",
                "Exclusão de Planos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o plano?",
                "Exclusão de Planos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioPlanoDeCobranca.Excluir(planoSelecionado);
                CarregarPlanos();
            }
        }

        public override UserControl ObtemListagem()
        {
            listagemPlanos= new TabelaPlanoDeCobrancaControl();

            CarregarPlanos();

            return listagemPlanos;
        }

        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxPlanoDeCobranca();
        }

        private PlanoDeCobranca ObtemPlanoSelecionado()
        {
            var numero = listagemPlanos.ObtemNumeroPlanoSelecionado();

            return repositorioPlanoDeCobranca.SelecionarPorId(numero);
        }

        private void CarregarPlanos()
        {
            List<PlanoDeCobranca> planos = repositorioPlanoDeCobranca.SelecionarTodos();

            listagemPlanos.AtualizarRegistros(planos);

            TelaMenuPrincipalForm.Instancia.AtualizarRodape($"Visualizando {planos.Count} plano(s)");

        }

    }
}
