using System.Drawing;
using System.Windows.Forms;

namespace CRUD_cliente_IACO.Formularios.Cliente.Cadastrar
{
    partial class CadastroClienteForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.PrimeiroNome = new System.Windows.Forms.TextBox();
            this.Sobrenome = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.TextBox();
            this.Genero = new System.Windows.Forms.ComboBox();
            this.Btn_Proximo = new System.Windows.Forms.Button();
            this.CPF = new System.Windows.Forms.MaskedTextBox();
            this.Telefone = new System.Windows.Forms.MaskedTextBox();
            this.Btn_Limpar = new System.Windows.Forms.Button();
            this.DataDeNascimento = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(916, 78);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadastrar Cliente";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Primeiro Nome";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Sobrenome";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 322);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Genero";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(396, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "CPF";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(396, 245);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Data de Nascimento";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(396, 322);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "Telefone";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(665, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 17);
            this.label9.TabIndex = 15;
            this.label9.Text = "Email";
            // 
            // PrimeiroNome
            // 
            this.PrimeiroNome.Location = new System.Drawing.Point(87, 178);
            this.PrimeiroNome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PrimeiroNome.Name = "PrimeiroNome";
            this.PrimeiroNome.Size = new System.Drawing.Size(168, 22);
            this.PrimeiroNome.TabIndex = 2;
            // 
            // Sobrenome
            // 
            this.Sobrenome.Location = new System.Drawing.Point(87, 263);
            this.Sobrenome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Sobrenome.Name = "Sobrenome";
            this.Sobrenome.Size = new System.Drawing.Size(168, 22);
            this.Sobrenome.TabIndex = 4;
            this.Sobrenome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Sobrenome_KeyPress);
            // 
            // Email
            // 
            this.Email.Location = new System.Drawing.Point(669, 178);
            this.Email.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(168, 22);
            this.Email.TabIndex = 16;
            // 
            // Genero
            // 
            this.Genero.FormattingEnabled = true;
            this.Genero.Location = new System.Drawing.Point(87, 341);
            this.Genero.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Genero.Name = "Genero";
            this.Genero.Size = new System.Drawing.Size(168, 24);
            this.Genero.TabIndex = 6;
            // 
            // Btn_Proximo
            // 
            this.Btn_Proximo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Btn_Proximo.Location = new System.Drawing.Point(740, 416);
            this.Btn_Proximo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Proximo.Name = "Btn_Proximo";
            this.Btn_Proximo.Size = new System.Drawing.Size(93, 34);
            this.Btn_Proximo.TabIndex = 18;
            this.Btn_Proximo.Text = "Próximo";
            this.Btn_Proximo.UseVisualStyleBackColor = false;
            this.Btn_Proximo.Click += new System.EventHandler(this.Btn_Proximo_Click);
            // 
            // CPF
            // 
            this.CPF.Location = new System.Drawing.Point(400, 178);
            this.CPF.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CPF.Mask = "000,000,000-00";
            this.CPF.Name = "CPF";
            this.CPF.Size = new System.Drawing.Size(168, 22);
            this.CPF.TabIndex = 10;
            // 
            // Telefone
            // 
            this.Telefone.Location = new System.Drawing.Point(400, 342);
            this.Telefone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Telefone.Mask = "00 00000-0000";
            this.Telefone.Name = "Telefone";
            this.Telefone.Size = new System.Drawing.Size(168, 22);
            this.Telefone.TabIndex = 14;
            // 
            // Btn_Limpar
            // 
            this.Btn_Limpar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Btn_Limpar.Location = new System.Drawing.Point(615, 416);
            this.Btn_Limpar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Limpar.Name = "Btn_Limpar";
            this.Btn_Limpar.Size = new System.Drawing.Size(93, 34);
            this.Btn_Limpar.TabIndex = 17;
            this.Btn_Limpar.Text = "Limpar";
            this.Btn_Limpar.UseVisualStyleBackColor = false;
            this.Btn_Limpar.Click += new System.EventHandler(this.Btn_Limpar_Click);
            // 
            // DataDeNascimento
            // 
            this.DataDeNascimento.CustomFormat = "dd/MM/yyyy";
            this.DataDeNascimento.Location = new System.Drawing.Point(400, 265);
            this.DataDeNascimento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DataDeNascimento.Name = "DataDeNascimento";
            this.DataDeNascimento.Size = new System.Drawing.Size(168, 22);
            this.DataDeNascimento.TabIndex = 12;
            // 
            // CadastroClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 496);
            this.Controls.Add(this.DataDeNascimento);
            this.Controls.Add(this.Btn_Limpar);
            this.Controls.Add(this.Telefone);
            this.Controls.Add(this.CPF);
            this.Controls.Add(this.Genero);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.Sobrenome);
            this.Controls.Add(this.PrimeiroNome);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_Proximo);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CadastroClienteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de dados pessoais";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox PrimeiroNome;
        private TextBox Sobrenome;
        private TextBox Email;
        private ComboBox Genero;
        private Button Btn_Proximo;
        private MaskedTextBox CPF;
        private MaskedTextBox Telefone;
        private Button Btn_Limpar;
        private DateTimePicker DataDeNascimento;
    }
}
