namespace LocadoraDeVeiculos.WinApp.ModuloPlanoDeCobranca
{
    partial class TelaCadastroPlanoDeCobranca
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
            this.cbTipoDePlano = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtDiario = new System.Windows.Forms.TextBox();
            this.txtKmIncluso = new System.Windows.Forms.TextBox();
            this.txtKmRodado = new System.Windows.Forms.TextBox();
            this.cbGrupoDeVeiculo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbTipoDePlano
            // 
            this.cbTipoDePlano.FormattingEnabled = true;
            this.cbTipoDePlano.Location = new System.Drawing.Point(172, 29);
            this.cbTipoDePlano.Name = "cbTipoDePlano";
            this.cbTipoDePlano.Size = new System.Drawing.Size(151, 23);
            this.cbTipoDePlano.TabIndex = 0;
            this.cbTipoDePlano.SelectedIndexChanged += new System.EventHandler(this.cbTipoDePlano_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo de Plano:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Valor Diário:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Valor Km Incluso:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Preço Km Rodado:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Grupo De Veículo:";
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(91, 252);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(102, 41);
            this.btnGravar.TabIndex = 6;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(210, 252);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(102, 41);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtDiario
            // 
            this.txtDiario.Location = new System.Drawing.Point(172, 68);
            this.txtDiario.Name = "txtDiario";
            this.txtDiario.Size = new System.Drawing.Size(151, 23);
            this.txtDiario.TabIndex = 8;
            // 
            // txtKmIncluso
            // 
            this.txtKmIncluso.Location = new System.Drawing.Point(172, 104);
            this.txtKmIncluso.Name = "txtKmIncluso";
            this.txtKmIncluso.Size = new System.Drawing.Size(151, 23);
            this.txtKmIncluso.TabIndex = 9;
            // 
            // txtKmRodado
            // 
            this.txtKmRodado.Location = new System.Drawing.Point(172, 142);
            this.txtKmRodado.Name = "txtKmRodado";
            this.txtKmRodado.Size = new System.Drawing.Size(151, 23);
            this.txtKmRodado.TabIndex = 10;
            // 
            // cbGrupoDeVeiculo
            // 
            this.cbGrupoDeVeiculo.FormattingEnabled = true;
            this.cbGrupoDeVeiculo.Location = new System.Drawing.Point(172, 182);
            this.cbGrupoDeVeiculo.Name = "cbGrupoDeVeiculo";
            this.cbGrupoDeVeiculo.Size = new System.Drawing.Size(151, 23);
            this.cbGrupoDeVeiculo.TabIndex = 11;
            this.cbGrupoDeVeiculo.SelectedIndexChanged += new System.EventHandler(this.cbGrupoDeVeiculo_SelectedIndexChanged);
            // 
            // TelaCadastroPlanoDeCobranca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 305);
            this.Controls.Add(this.cbGrupoDeVeiculo);
            this.Controls.Add(this.txtKmRodado);
            this.Controls.Add(this.txtKmIncluso);
            this.Controls.Add(this.txtDiario);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbTipoDePlano);
            this.Name = "TelaCadastroPlanoDeCobranca";
            this.ShowIcon = false;
            this.Text = "Cadastro de Plano de Cobrança";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTipoDePlano;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtDiario;
        private System.Windows.Forms.TextBox txtKmIncluso;
        private System.Windows.Forms.TextBox txtKmRodado;
        private System.Windows.Forms.ComboBox cbGrupoDeVeiculo;
    }
}