using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
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
    public partial class TelaCadastroVeiculoForm : Form
    {
        private Veiculo veiculo;
        public TelaCadastroVeiculoForm(List<GrupoDeVeiculos> grupos)
        {
            InitializeComponent();
            this.ConfigurarTela();
            CarregarGrupos(grupos);
        }

        public Veiculo Veiculo
        {
            get { return veiculo; }
            set
            {
                veiculo = value;
                comboBoxGrupoDeVeiculos.SelectedItem = veiculo.GruposDeVeiculos;
                textBoxModelo.Text = veiculo.Modelo;
                textBoxMarca.Text = veiculo.Marca;
                textBoxPlaca.Text = veiculo.Placa;
                comboBoxTipoCombustivel.SelectedItem = veiculo.TipoDeCombustivel;
                int capaciadade = int.Parse(textBoxCapacidadeTanque.Text);
                capaciadade = veiculo.CapacidadeDoTanque;
                DateTime ano = Convert.ToDateTime(textBoxAno.Text);
                ano = veiculo.Ano;
                int kmPercorrido = int.Parse(textBoxKmPercorrido.Text);
                kmPercorrido = veiculo.KmPercorrido;
                pictureBox1.Image = veiculo.Foto;

            }
        }

        private void CarregarGrupos(List<GrupoDeVeiculos> grupos)
        {
            comboBoxGrupoDeVeiculos.Items.Clear();

            foreach (var item in grupos)
            {
                comboBoxGrupoDeVeiculos.Items.Add(item);
            }
        }
        public Func<Veiculo, ValidationResult> GravarRegistro { get; set; }

        //Metodos privados :
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void buttonSelecionarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Image image = Image.FromFile(ofd.FileName);
                pictureBox1.Image = image;
            }
        }

        private void TelaCadastroVeiculo_Load(object sender, EventArgs e)
        {
            TelaMenuPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void comboBoxGrupoDeVeiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBoxTipoCombustivel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TelaCadastroVeiculo_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaMenuPrincipalForm.Instancia.AtualizarRodape("");
        }
    }
}
