using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloVeiculo
{
    public partial class TelaCadastroVeiculoForm : Form
    {
        private Veiculo veiculo = new Veiculo();

        ServicoGrupoDeVeiculos servicoGrupoDeVeiculos;
        public TelaCadastroVeiculoForm(List<GrupoDeVeiculos> grupos, ServicoGrupoDeVeiculos servicoGrupoDeVeiculos)
        {
            this.ConfigurarTela();
            InitializeComponent();
            CarregarGrupos(grupos);
            this.servicoGrupoDeVeiculos = servicoGrupoDeVeiculos;
        }
        public Func<Veiculo, Result<Veiculo>> GravarRegistro { get; set; }
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
                textBoxCor.Text = veiculo.Cor;
                comboBoxTipoCombustivel.SelectedItem = veiculo.TipoDeCombustivel;
                textBoxCapacidadeTanque.Text = veiculo.CapacidadeDoTanque.ToString();
                textBoxAno.Text = veiculo.Ano.ToString();
                textBoxKmPercorrido.Text = veiculo.KmPercorrido.ToString();
                if (veiculo.Foto != null)
                {
                    byte[] data = veiculo.Foto;
                    var foto = Image.FromStream(new System.IO.MemoryStream(data));
                    pictureBox1.Image = foto;
                }

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

        //Metodos privados :
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void buttonSelecionarFoto_Click(object sender, EventArgs e)
        {
           

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(ofd.FileName);
                pictureBox1.Image = image;
            }
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            byte[] buff = ms.GetBuffer();

            veiculo.Foto = buff;

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

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            veiculo.GruposDeVeiculos = (GrupoDeVeiculos)comboBoxGrupoDeVeiculos.SelectedItem;
            veiculo.Modelo = textBoxModelo.Text;
            veiculo.Marca = textBoxMarca.Text;
            veiculo.Placa = textBoxPlaca.Text;
            veiculo.Cor = textBoxCor.Text;
            if (comboBoxTipoCombustivel.SelectedItem.Equals("Gasolina comum"))
            {
                veiculo.TipoDeCombustivel = TipoCombustivel.GasolinaComum;
            }
            else if (comboBoxTipoCombustivel.SelectedItem.Equals("Gasolina aditivada"))
            {
                veiculo.TipoDeCombustivel = TipoCombustivel.GasolinaAditivada;
            }
            else if (comboBoxTipoCombustivel.SelectedItem.Equals("Etanol"))
            {
                veiculo.TipoDeCombustivel = TipoCombustivel.Etanol;
            }
            else if (comboBoxTipoCombustivel.SelectedItem.Equals("Diesel"))
            {
                veiculo.TipoDeCombustivel = TipoCombustivel.Diesel;
            }

            //veiculo.TipoDeCombustivel = (String)comboBoxTipoCombustivel.SelectedItem;
            veiculo.CapacidadeDoTanque = int.Parse(textBoxCapacidadeTanque.Text);
            veiculo.Ano = DateTime.Parse(textBoxAno.Text);
            veiculo.KmPercorrido = int.Parse(textBoxKmPercorrido.Text);
           
            MemoryStream ms = new MemoryStream();

            pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            byte[] buff = ms.GetBuffer();

            veiculo.Foto = buff;

            var resultadoValidacao = GravarRegistro(veiculo);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção de Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaMenuPrincipalForm.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
        }
    }
}
