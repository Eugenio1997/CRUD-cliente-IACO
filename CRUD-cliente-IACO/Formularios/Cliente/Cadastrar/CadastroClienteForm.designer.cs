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
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(515, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadastrar Cliente";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 97);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Primeiro Nome";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 151);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Sobrenome";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 203);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Genero";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(223, 95);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "CPF";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(222, 150);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Data de Nascimento";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(223, 203);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Telefone";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(395, 96);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Email";
            // 
            // PrimeiroNome
            // 
            this.PrimeiroNome.Location = new System.Drawing.Point(50, 111);
            this.PrimeiroNome.Margin = new System.Windows.Forms.Padding(2);
            this.PrimeiroNome.Name = "PrimeiroNome";
            this.PrimeiroNome.Size = new System.Drawing.Size(95, 20);
            this.PrimeiroNome.TabIndex = 2;
            // 
            // Sobrenome
            // 
            this.Sobrenome.Location = new System.Drawing.Point(50, 166);
            this.Sobrenome.Margin = new System.Windows.Forms.Padding(2);
            this.Sobrenome.Name = "Sobrenome";
            this.Sobrenome.Size = new System.Drawing.Size(95, 20);
            this.Sobrenome.TabIndex = 4;
            // 
            // Email
            // 
            this.Email.Location = new System.Drawing.Point(395, 111);
            this.Email.Margin = new System.Windows.Forms.Padding(2);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(95, 20);
            this.Email.TabIndex = 16;
            // 
            // Genero
            // 
            this.Genero.FormattingEnabled = true;
            this.Genero.Location = new System.Drawing.Point(50, 218);
            this.Genero.Margin = new System.Windows.Forms.Padding(2);
            this.Genero.Name = "Genero";
            this.Genero.Size = new System.Drawing.Size(95, 21);
            this.Genero.TabIndex = 6;
            // 
            // Btn_Proximo
            // 
            this.Btn_Proximo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Btn_Proximo.Location = new System.Drawing.Point(420, 270);
            this.Btn_Proximo.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Proximo.Name = "Btn_Proximo";
            this.Btn_Proximo.Size = new System.Drawing.Size(70, 28);
            this.Btn_Proximo.TabIndex = 18;
            this.Btn_Proximo.Text = "Próximo";
            this.Btn_Proximo.UseVisualStyleBackColor = false;
            // 
            // CPF
            // 
            this.CPF.Location = new System.Drawing.Point(223, 111);
            this.CPF.Mask = "000.000.000-00";
            this.CPF.Name = "CPF";
            this.CPF.Size = new System.Drawing.Size(100, 20);
            this.CPF.TabIndex = 10;
            // 
            // Telefone
            // 
            this.Telefone.Location = new System.Drawing.Point(223, 219);
            this.Telefone.Mask = "00 00000-0000";
            this.Telefone.Name = "Telefone";
            this.Telefone.Size = new System.Drawing.Size(100, 20);
            this.Telefone.TabIndex = 14;
            // 
            // Btn_Limpar
            // 
            this.Btn_Limpar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Btn_Limpar.Location = new System.Drawing.Point(326, 270);
            this.Btn_Limpar.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Limpar.Name = "Btn_Limpar";
            this.Btn_Limpar.Size = new System.Drawing.Size(70, 28);
            this.Btn_Limpar.TabIndex = 17;
            this.Btn_Limpar.Text = "Limpar";
            this.Btn_Limpar.UseVisualStyleBackColor = false;
            // 
            // DataDeNascimento
            // 
            this.DataDeNascimento.Location = new System.Drawing.Point(223, 166);
            this.DataDeNascimento.Name = "DataDeNascimento";
            this.DataDeNascimento.Size = new System.Drawing.Size(100, 20);
            this.DataDeNascimento.TabIndex = 12;
            // 
            // CadastroClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 320);
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
            this.Margin = new System.Windows.Forms.Padding(2);
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
