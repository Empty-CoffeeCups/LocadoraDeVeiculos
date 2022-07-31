using FluentResults;
using LocadoraDeVeiculos.Aplicacao.ModuloLocacao;
using LocadoraDeVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
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
    public partial class TelaCadastroDevolucaoForm : Form
    {
        public Devolucao Devolucao = new Devolucao();
        private ServicoLocacao servicoLocacao;
        List<Locacao> locacoes;

        public TelaCadastroDevolucaoForm(ServicoLocacao servicoLocacao, ServicoTaxa servicoTaxa , ServicoPlanoDeCobranca servicoPlanoDeCobranca)
        {
            InitializeComponent();
            this.servicoLocacao = servicoLocacao;
            locacoes = servicoLocacao.SelecionarTodos().Value;
        }

        public Func<Devolucao, Result<Devolucao>> GravarRegistro { get; set; }
    }
}
