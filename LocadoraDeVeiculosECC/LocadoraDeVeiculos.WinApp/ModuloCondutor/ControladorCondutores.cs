using locadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
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
        private readonly RepositorioClienteEmBancoDados repositorioCliente = new RepositorioClienteEmBancoDados();

        private TabelaCondutorControl listagemCondutores;
        private readonly ServicoCondutor servicoCondutor;
        private readonly ServicoCliente servicoCliente;
       

        public ControladorCondutores(ServicoCondutor servicoCondutor, ServicoCliente servicoCliente)
        {
            this.servicoCondutor = servicoCondutor;
            this.servicoCliente = servicoCliente;
            this.repositorioCliente = repositorioCliente;
        }

        public override void Inserir()
        {
            var clientes = servicoCliente.SelecionarTodos().Value;

            TelaCadastroCondutorForm tela = new TelaCadastroCondutorForm(clientes);

            tela.Condutor = new Condutor();

            tela.GravarRegistro = servicoCondutor.Inserir;

            DialogResult result = tela.ShowDialog();

            if (result == DialogResult.OK)
            {
                CarregarCondutor();
            }
        }

        public override void Editar()
        {
            var id = listagemCondutores.ObtemIdCondutorSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um Condutor primeiro",
                    "Edição de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoCondutor.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var planoSelecionado = resultado.Value;

            var clientes = servicoCliente.SelecionarTodos().Value;

            var tela = new TelaCadastroCondutorForm(clientes);

            tela.Condutor = planoSelecionado.Clonar();

            tela.GravarRegistro = servicoCondutor.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarCondutor();
        }

        public override void Excluir()
        {
            var id = listagemCondutores.ObtemIdCondutorSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um Condutor primeiro",
                    "Exclusão de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoCondutor.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var planoSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o Condutor?", "Exclusão de Condutor",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoCondutor.Excluir(planoSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarCondutor();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxCondutor();
        }

        public override UserControl ObtemListagem()
        {
            if (listagemCondutores == null)
                listagemCondutores = new TabelaCondutorControl();

            CarregarCondutor();

            return listagemCondutores;
        }

        private void CarregarCondutor()
        {
            var resultado = servicoCondutor.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Condutor> condutores = resultado.Value;

                listagemCondutores.AtualizarRegistros(condutores);

                TelaMenuPrincipalForm.Instancia.AtualizarRodape($"Visualizando {condutores.Count} Condutor(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Condutor",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


    }
}
