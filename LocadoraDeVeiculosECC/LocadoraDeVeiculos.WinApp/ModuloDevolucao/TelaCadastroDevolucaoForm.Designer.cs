﻿namespace LocadoraDeVeiculos.WinApp.ModuloDevolucao
{
    partial class TelaCadastroDevolucaoForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.txtFuncionario = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtVeiculo = new System.Windows.Forms.TextBox();
            this.txtGrupoDeVeiculo = new System.Windows.Forms.TextBox();
            this.txtPlanoDeCobranca = new System.Windows.Forms.TextBox();
            this.txtDataDeLocacao = new System.Windows.Forms.TextBox();
            this.txtDevolucaoPrevista = new System.Windows.Forms.TextBox();
            this.txtKmDoVeiculo = new System.Windows.Forms.TextBox();
            this.dtpDataDeDevolucao = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbLocacao = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gpTaxasDevolucao = new System.Windows.Forms.GroupBox();
            this.cbTranslado = new System.Windows.Forms.CheckBox();
            this.cbManutencao = new System.Windows.Forms.CheckBox();
            this.cbLavagem = new System.Windows.Forms.CheckBox();
            this.gpTaxasLocacao = new System.Windows.Forms.GroupBox();
            this.cbTaxasLocacao = new System.Windows.Forms.CheckedListBox();
            this.cmbNivelDoTanque = new System.Windows.Forms.ComboBox();
            this.gpTaxasDevolucao.SuspendLayout();
            this.gpTaxasLocacao.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Funcionário:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cliente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Grupo De Veículo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Veículo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 289);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Plano De Cobrança:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 333);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Data da Locação:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 374);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Devolução Prevista:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 418);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Km do Veículo:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(2, 469);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "Data de Devolução:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 519);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 15);
            this.label11.TabIndex = 10;
            this.label11.Text = "Nível do Tanque:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(47, 728);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 15);
            this.label12.TabIndex = 11;
            this.label12.Text = "Valor Total:";
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(569, 749);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(92, 41);
            this.btnGravar.TabIndex = 12;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(682, 749);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(92, 41);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Enabled = false;
            this.txtValorTotal.Location = new System.Drawing.Point(153, 720);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(119, 23);
            this.txtValorTotal.TabIndex = 14;
            // 
            // txtFuncionario
            // 
            this.txtFuncionario.Enabled = false;
            this.txtFuncionario.Location = new System.Drawing.Point(153, 101);
            this.txtFuncionario.Name = "txtFuncionario";
            this.txtFuncionario.Size = new System.Drawing.Size(416, 23);
            this.txtFuncionario.TabIndex = 15;
            // 
            // txtCliente
            // 
            this.txtCliente.Enabled = false;
            this.txtCliente.Location = new System.Drawing.Point(153, 145);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(416, 23);
            this.txtCliente.TabIndex = 16;
            // 
            // txtVeiculo
            // 
            this.txtVeiculo.Enabled = false;
            this.txtVeiculo.Location = new System.Drawing.Point(153, 191);
            this.txtVeiculo.Name = "txtVeiculo";
            this.txtVeiculo.Size = new System.Drawing.Size(416, 23);
            this.txtVeiculo.TabIndex = 17;
            // 
            // txtGrupoDeVeiculo
            // 
            this.txtGrupoDeVeiculo.Enabled = false;
            this.txtGrupoDeVeiculo.Location = new System.Drawing.Point(153, 236);
            this.txtGrupoDeVeiculo.Name = "txtGrupoDeVeiculo";
            this.txtGrupoDeVeiculo.Size = new System.Drawing.Size(416, 23);
            this.txtGrupoDeVeiculo.TabIndex = 18;
            // 
            // txtPlanoDeCobranca
            // 
            this.txtPlanoDeCobranca.Enabled = false;
            this.txtPlanoDeCobranca.Location = new System.Drawing.Point(153, 281);
            this.txtPlanoDeCobranca.Name = "txtPlanoDeCobranca";
            this.txtPlanoDeCobranca.Size = new System.Drawing.Size(416, 23);
            this.txtPlanoDeCobranca.TabIndex = 19;
            // 
            // txtDataDeLocacao
            // 
            this.txtDataDeLocacao.Enabled = false;
            this.txtDataDeLocacao.Location = new System.Drawing.Point(153, 325);
            this.txtDataDeLocacao.Name = "txtDataDeLocacao";
            this.txtDataDeLocacao.Size = new System.Drawing.Size(416, 23);
            this.txtDataDeLocacao.TabIndex = 20;
            // 
            // txtDevolucaoPrevista
            // 
            this.txtDevolucaoPrevista.Enabled = false;
            this.txtDevolucaoPrevista.Location = new System.Drawing.Point(153, 366);
            this.txtDevolucaoPrevista.Name = "txtDevolucaoPrevista";
            this.txtDevolucaoPrevista.Size = new System.Drawing.Size(416, 23);
            this.txtDevolucaoPrevista.TabIndex = 21;
            // 
            // txtKmDoVeiculo
            // 
            this.txtKmDoVeiculo.Location = new System.Drawing.Point(153, 410);
            this.txtKmDoVeiculo.Name = "txtKmDoVeiculo";
            this.txtKmDoVeiculo.Size = new System.Drawing.Size(416, 23);
            this.txtKmDoVeiculo.TabIndex = 23;
            // 
            // dtpDataDeDevolucao
            // 
            this.dtpDataDeDevolucao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataDeDevolucao.Location = new System.Drawing.Point(153, 461);
            this.dtpDataDeDevolucao.Name = "dtpDataDeDevolucao";
            this.dtpDataDeDevolucao.Size = new System.Drawing.Size(241, 23);
            this.dtpDataDeDevolucao.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(67, 59);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 15);
            this.label13.TabIndex = 27;
            this.label13.Text = "Locação:";
            // 
            // cmbLocacao
            // 
            this.cmbLocacao.FormattingEnabled = true;
            this.cmbLocacao.Location = new System.Drawing.Point(153, 51);
            this.cmbLocacao.Name = "cmbLocacao";
            this.cmbLocacao.Size = new System.Drawing.Size(416, 23);
            this.cmbLocacao.TabIndex = 28;
            this.cmbLocacao.SelectedIndexChanged += new System.EventHandler(this.cmbLocacao_SelectedIndexChanged);
            // 
            // gpTaxasDevolucao
            // 
            this.gpTaxasDevolucao.Controls.Add(this.cbTranslado);
            this.gpTaxasDevolucao.Controls.Add(this.cbManutencao);
            this.gpTaxasDevolucao.Controls.Add(this.cbLavagem);
            this.gpTaxasDevolucao.Location = new System.Drawing.Point(38, 562);
            this.gpTaxasDevolucao.Name = "gpTaxasDevolucao";
            this.gpTaxasDevolucao.Size = new System.Drawing.Size(286, 137);
            this.gpTaxasDevolucao.TabIndex = 29;
            this.gpTaxasDevolucao.TabStop = false;
            this.gpTaxasDevolucao.Text = "Taxas Devolução";
            // 
            // cbTranslado
            // 
            this.cbTranslado.AutoSize = true;
            this.cbTranslado.Location = new System.Drawing.Point(9, 81);
            this.cbTranslado.Name = "cbTranslado";
            this.cbTranslado.Size = new System.Drawing.Size(110, 19);
            this.cbTranslado.TabIndex = 3;
            this.cbTranslado.Text = "Translado 100R$";
            this.cbTranslado.UseVisualStyleBackColor = true;
            this.cbTranslado.CheckedChanged += new System.EventHandler(this.cbTranslado_CheckedChanged);
            // 
            // cbManutencao
            // 
            this.cbManutencao.AutoSize = true;
            this.cbManutencao.Location = new System.Drawing.Point(9, 56);
            this.cbManutencao.Name = "cbManutencao";
            this.cbManutencao.Size = new System.Drawing.Size(127, 19);
            this.cbManutencao.TabIndex = 2;
            this.cbManutencao.Text = "Manutenção 150R$";
            this.cbManutencao.UseVisualStyleBackColor = true;
            this.cbManutencao.CheckedChanged += new System.EventHandler(this.cbManutencao_CheckedChanged);
            // 
            // cbLavagem
            // 
            this.cbLavagem.AutoSize = true;
            this.cbLavagem.Location = new System.Drawing.Point(9, 31);
            this.cbLavagem.Name = "cbLavagem";
            this.cbLavagem.Size = new System.Drawing.Size(114, 19);
            this.cbLavagem.TabIndex = 0;
            this.cbLavagem.Text = "Lavar Carro 50R$";
            this.cbLavagem.UseVisualStyleBackColor = true;
            this.cbLavagem.CheckedChanged += new System.EventHandler(this.cbLavagem_CheckedChanged);
            // 
            // gpTaxasLocacao
            // 
            this.gpTaxasLocacao.Controls.Add(this.cbTaxasLocacao);
            this.gpTaxasLocacao.Location = new System.Drawing.Point(382, 562);
            this.gpTaxasLocacao.Name = "gpTaxasLocacao";
            this.gpTaxasLocacao.Size = new System.Drawing.Size(392, 165);
            this.gpTaxasLocacao.TabIndex = 30;
            this.gpTaxasLocacao.TabStop = false;
            this.gpTaxasLocacao.Text = "Taxas Locação";
            // 
            // cbTaxasLocacao
            // 
            this.cbTaxasLocacao.FormattingEnabled = true;
            this.cbTaxasLocacao.Location = new System.Drawing.Point(18, 22);
            this.cbTaxasLocacao.Name = "cbTaxasLocacao";
            this.cbTaxasLocacao.Size = new System.Drawing.Size(355, 130);
            this.cbTaxasLocacao.TabIndex = 0;
            // 
            // cmbNivelDoTanque
            // 
            this.cmbNivelDoTanque.FormattingEnabled = true;
            this.cmbNivelDoTanque.Items.AddRange(new object[] {
            "Vazio",
            "1/4",
            "1/2",
            "3/4",
            "Cheio"});
            this.cmbNivelDoTanque.Location = new System.Drawing.Point(153, 516);
            this.cmbNivelDoTanque.Name = "cmbNivelDoTanque";
            this.cmbNivelDoTanque.Size = new System.Drawing.Size(121, 23);
            this.cmbNivelDoTanque.TabIndex = 31;
            this.cmbNivelDoTanque.SelectedIndexChanged += new System.EventHandler(this.cmbNivelDoTanque_SelectedIndexChanged);
            // 
            // TelaCadastroDevolucaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 831);
            this.Controls.Add(this.cmbNivelDoTanque);
            this.Controls.Add(this.gpTaxasLocacao);
            this.Controls.Add(this.gpTaxasDevolucao);
            this.Controls.Add(this.cmbLocacao);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dtpDataDeDevolucao);
            this.Controls.Add(this.txtKmDoVeiculo);
            this.Controls.Add(this.txtDevolucaoPrevista);
            this.Controls.Add(this.txtDataDeLocacao);
            this.Controls.Add(this.txtPlanoDeCobranca);
            this.Controls.Add(this.txtGrupoDeVeiculo);
            this.Controls.Add(this.txtVeiculo);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.txtFuncionario);
            this.Controls.Add(this.txtValorTotal);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TelaCadastroDevolucaoForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro De Devolução";
            this.gpTaxasDevolucao.ResumeLayout(false);
            this.gpTaxasDevolucao.PerformLayout();
            this.gpTaxasLocacao.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.TextBox txtFuncionario;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtVeiculo;
        private System.Windows.Forms.TextBox txtGrupoDeVeiculo;
        private System.Windows.Forms.TextBox txtPlanoDeCobranca;
        private System.Windows.Forms.TextBox txtDataDeLocacao;
        private System.Windows.Forms.TextBox txtDevolucaoPrevista;
        private System.Windows.Forms.TextBox txtKmDoVeiculo;
        private System.Windows.Forms.DateTimePicker dtpDataDeDevolucao;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbLocacao;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox gpTaxasDevolucao;
        private System.Windows.Forms.GroupBox gpTaxasLocacao;
        private System.Windows.Forms.CheckBox cbManutencao;
        private System.Windows.Forms.CheckBox cbLavagem;
        private System.Windows.Forms.CheckedListBox cbTaxasLocacao;
        private System.Windows.Forms.CheckBox cbTranslado;
        private System.Windows.Forms.ComboBox cmbNivelDoTanque;
    }
}