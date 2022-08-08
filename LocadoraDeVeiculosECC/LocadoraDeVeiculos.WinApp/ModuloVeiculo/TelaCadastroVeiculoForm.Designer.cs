namespace LocadoraDeVeiculos.WinApp.ModuloVeiculo
{
    partial class TelaCadastroVeiculoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonGravar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxGrupoDeVeiculos = new System.Windows.Forms.ComboBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.textBoxModelo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMarca = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPlaca = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxCor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxCapacidadeTanque = new System.Windows.Forms.TextBox();
            this.comboBoxTipoCombustivel = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxAno = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxKmPercorrido = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonSelecionarFoto = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGravar
            // 
            this.buttonGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGravar.Location = new System.Drawing.Point(276, 465);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(75, 39);
            this.buttonGravar.TabIndex = 0;
            this.buttonGravar.Text = "GRAVAR";
            this.buttonGravar.UseVisualStyleBackColor = true;
            this.buttonGravar.Click += new System.EventHandler(this.buttonGravar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(357, 465);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 39);
            this.buttonCancelar.TabIndex = 1;
            this.buttonCancelar.Text = "CANCELAR";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Id :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Grupo :";
            // 
            // comboBoxGrupoDeVeiculos
            // 
            this.comboBoxGrupoDeVeiculos.FormattingEnabled = true;
            this.comboBoxGrupoDeVeiculos.Location = new System.Drawing.Point(98, 77);
            this.comboBoxGrupoDeVeiculos.Name = "comboBoxGrupoDeVeiculos";
            this.comboBoxGrupoDeVeiculos.Size = new System.Drawing.Size(308, 23);
            this.comboBoxGrupoDeVeiculos.TabIndex = 4;
            this.comboBoxGrupoDeVeiculos.SelectedIndexChanged += new System.EventHandler(this.comboBoxGrupoDeVeiculos_SelectedIndexChanged);
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(98, 38);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(100, 23);
            this.textBoxId.TabIndex = 5;
            // 
            // textBoxModelo
            // 
            this.textBoxModelo.Location = new System.Drawing.Point(98, 106);
            this.textBoxModelo.Name = "textBoxModelo";
            this.textBoxModelo.Size = new System.Drawing.Size(121, 23);
            this.textBoxModelo.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Modelo :";
            // 
            // textBoxMarca
            // 
            this.textBoxMarca.Location = new System.Drawing.Point(293, 109);
            this.textBoxMarca.Name = "textBoxMarca";
            this.textBoxMarca.Size = new System.Drawing.Size(113, 23);
            this.textBoxMarca.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Marca :";
            // 
            // textBoxPlaca
            // 
            this.textBoxPlaca.Location = new System.Drawing.Point(98, 145);
            this.textBoxPlaca.Name = "textBoxPlaca";
            this.textBoxPlaca.Size = new System.Drawing.Size(121, 23);
            this.textBoxPlaca.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Placa :";
            // 
            // textBoxCor
            // 
            this.textBoxCor.Location = new System.Drawing.Point(295, 148);
            this.textBoxCor.Name = "textBoxCor";
            this.textBoxCor.Size = new System.Drawing.Size(111, 23);
            this.textBoxCor.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(257, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Cor :";
            // 
            // textBoxCapacidadeTanque
            // 
            this.textBoxCapacidadeTanque.Location = new System.Drawing.Point(295, 192);
            this.textBoxCapacidadeTanque.Name = "textBoxCapacidadeTanque";
            this.textBoxCapacidadeTanque.Size = new System.Drawing.Size(111, 23);
            this.textBoxCapacidadeTanque.TabIndex = 15;
            // 
            // comboBoxTipoCombustivel
            // 
            this.comboBoxTipoCombustivel.FormattingEnabled = true;
            this.comboBoxTipoCombustivel.Items.AddRange(new object[] {
            "Gasolina comum",
            "Gasolina aditivada",
            "Etanol",
            "Diesel"});
            this.comboBoxTipoCombustivel.Location = new System.Drawing.Point(98, 187);
            this.comboBoxTipoCombustivel.Name = "comboBoxTipoCombustivel";
            this.comboBoxTipoCombustivel.Size = new System.Drawing.Size(121, 23);
            this.comboBoxTipoCombustivel.TabIndex = 17;
            this.comboBoxTipoCombustivel.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoCombustivel_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "combustivel :";
            // 
            // textBoxAno
            // 
            this.textBoxAno.Location = new System.Drawing.Point(98, 228);
            this.textBoxAno.Name = "textBoxAno";
            this.textBoxAno.Size = new System.Drawing.Size(121, 23);
            this.textBoxAno.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(60, 231);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 15);
            this.label9.TabIndex = 18;
            this.label9.Text = "Ano :";
            // 
            // textBoxKmPercorrido
            // 
            this.textBoxKmPercorrido.Location = new System.Drawing.Point(298, 231);
            this.textBoxKmPercorrido.Name = "textBoxKmPercorrido";
            this.textBoxKmPercorrido.Size = new System.Drawing.Size(108, 23);
            this.textBoxKmPercorrido.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(229, 243);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 15);
            this.label10.TabIndex = 20;
            this.label10.Text = "percorrido :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(43, 180);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 15);
            this.label11.TabIndex = 22;
            this.label11.Text = "Tipo de";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(267, 228);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 15);
            this.label12.TabIndex = 23;
            this.label12.Text = "Km";
            // 
            // buttonSelecionarFoto
            // 
            this.buttonSelecionarFoto.Location = new System.Drawing.Point(204, 278);
            this.buttonSelecionarFoto.Name = "buttonSelecionarFoto";
            this.buttonSelecionarFoto.Size = new System.Drawing.Size(111, 27);
            this.buttonSelecionarFoto.TabIndex = 24;
            this.buttonSelecionarFoto.Text = "Selecionar Foto";
            this.buttonSelecionarFoto.UseVisualStyleBackColor = true;
            this.buttonSelecionarFoto.Click += new System.EventHandler(this.buttonSelecionarFoto_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(161, 284);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 15);
            this.label13.TabIndex = 25;
            this.label13.Text = "Foto :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(69, 311);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 148);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(229, 187);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 15);
            this.label14.TabIndex = 28;
            this.label14.Text = "Capacidade";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(229, 200);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 15);
            this.label15.TabIndex = 27;
            this.label15.Text = "do Tanque :";
            // 
            // TelaCadastroVeiculoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelar;
            this.ClientSize = new System.Drawing.Size(456, 516);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.buttonSelecionarFoto);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxKmPercorrido);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxAno);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBoxTipoCombustivel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxCapacidadeTanque);
            this.Controls.Add(this.textBoxCor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxPlaca);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxMarca);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxModelo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.comboBoxGrupoDeVeiculos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGravar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroVeiculoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Veiculo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelaCadastroVeiculo_FormClosing);
            this.Load += new System.EventHandler(this.TelaCadastroVeiculo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGravar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxGrupoDeVeiculos;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.TextBox textBoxModelo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxMarca;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPlaca;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxCor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxCapacidadeTanque;
        private System.Windows.Forms.ComboBox comboBoxTipoCombustivel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxAno;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxKmPercorrido;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonSelecionarFoto;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
    }
}