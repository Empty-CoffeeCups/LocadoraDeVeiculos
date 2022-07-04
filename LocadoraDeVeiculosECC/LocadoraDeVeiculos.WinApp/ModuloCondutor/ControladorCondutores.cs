using locadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloCondutor
{
    public class ControladorCondutores : ControladorBase
    {
        private readonly IRepositorioCondutor repositorioCondutor;
        private TabelaCondutorControl listagemCondutores;
        private readonly ServicoCondutor servicoCondutor;
        private readonly RepositorioClienteEmBancoDados repositorioCliente = new RepositorioClienteEmBancoDados();

        public ControladorCondutores(IRepositorioCondutor repositorioCondutor, ServicoCondutor servicoCondutor)
        {
            this.repositorioCondutor = repositorioCondutor;
            this.servicoCondutor = servicoCondutor;
            this.repositorioCliente = repositorioCliente;
        }

        public override void Inserir()
        {
            var clientes = repositorioCliente.SelecionarTodos();

            TelaCadastroCondutorForm tela = new TelaCadastroCondutorForm(clientes);

            tela.Condutor = new Condutor();

            tela.GravarRegistro = servicoCondutor.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarCondutores();
        }

        public override void Editar()
        {
            Condutor clienteSelecionado = ObtemCondutorSelecionado();

            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um condutor primeiro",
                "Edição de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var clientes = repositorioCliente.SelecionarTodos();

            TelaCadastroCondutorForm tela = new TelaCadastroCondutorForm(clientes);

            tela.Condutor = clienteSelecionado.Clonar();

            tela.GravarRegistro = servicoCondutor.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarCondutores();
        }

        public override void Excluir()
        {
            Condutor clienteSelecionado = ObtemCondutorSelecionado();

            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um Condutor primeiro",
                "Exclusão de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Condutor?",
                "Exclusão de Condutor", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
                repositorioCondutor.Excluir(clienteSelecionado);

            CarregarCondutores();
        }

        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxCondutor();
        }

        public override UserControl ObtemListagem()
        {
            if (listagemCondutores == null)
                listagemCondutores = new TabelaCondutorControl();

            CarregarCondutores();

            return listagemCondutores;
        }

        private void CarregarCondutores()
        {
            List<Condutor> condutores = repositorioCondutor.SelecionarTodos();

            listagemCondutores.AtualizarRegistros(condutores);

            TelaMenuPrincipalForm.Instancia.AtualizarRodape($"Visualizando {condutores.Count} condutores");
        }

        private Condutor ObtemCondutorSelecionado()
        {
            var id = listagemCondutores.ObtemIdCondutorSelecionado();

            return repositorioCondutor.SelecionarPorId(id);
        }
    }
}
