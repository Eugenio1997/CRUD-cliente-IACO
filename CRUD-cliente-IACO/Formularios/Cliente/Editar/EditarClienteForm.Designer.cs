namespace CRUD_cliente_IACO.Formularios.Cliente.Editar
{
    partial class EditarClienteForm
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
            this.DataDeNascimento = new System.Windows.Forms.DateTimePicker();
            this.Btn_Limpar = new System.Windows.Forms.Button();
            this.Telefone = new System.Windows.Forms.MaskedTextBox();
            this.CPF = new System.Windows.Forms.MaskedTextBox();
            this.Genero = new System.Windows.Forms.ComboBox();
            this.Email = new System.Windows.Forms.TextBox();
            this.Sobrenome = new System.Windows.Forms.TextBox();
            this.PrimeiroNome = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_Editar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DataDeNascimento
            // 
            this.DataDeNascimento.CustomFormat = "dd/MM/yyyy";
            this.DataDeNascimento.Location = new System.Drawing.Point(301, 230);
            this.DataDeNascimento.Name = "DataDeNascimento";
            this.DataDeNascimento.Size = new System.Drawing.Size(127, 20);
            this.DataDeNascimento.TabIndex = 29;
            // 
            // Btn_Limpar
            // 
            this.Btn_Limpar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Btn_Limpar.Location = new System.Drawing.Point(462, 353);
            this.Btn_Limpar.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Limpar.Name = "Btn_Limpar";
            this.Btn_Limpar.Size = new System.Drawing.Size(70, 28);
            this.Btn_Limpar.TabIndex = 34;
            this.Btn_Limpar.Text = "Limpar";
            this.Btn_Limpar.UseVisualStyleBackColor = false;
            // 
            // Telefone
            // 
            this.Telefone.Location = new System.Drawing.Point(301, 293);
            this.Telefone.Mask = "00 00000-0000";
            this.Telefone.Name = "Telefone";
            this.Telefone.Size = new System.Drawing.Size(127, 20);
            this.Telefone.TabIndex = 31;
            // 
            // CPF
            // 
            this.CPF.Location = new System.Drawing.Point(301, 160);
            this.CPF.Mask = "000,000,000-00";
            this.CPF.Name = "CPF";
            this.CPF.Size = new System.Drawing.Size(127, 20);
            this.CPF.TabIndex = 27;
            // 
            // Genero
            // 
            this.Genero.FormattingEnabled = true;
            this.Genero.Location = new System.Drawing.Point(66, 292);
            this.Genero.Margin = new System.Windows.Forms.Padding(2);
            this.Genero.Name = "Genero";
            this.Genero.Size = new System.Drawing.Size(127, 21);
            this.Genero.TabIndex = 25;
            // 
            // Email
            // 
            this.Email.Location = new System.Drawing.Point(503, 160);
            this.Email.Margin = new System.Windows.Forms.Padding(2);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(127, 20);
            this.Email.TabIndex = 33;
            // 
            // Sobrenome
            // 
            this.Sobrenome.Location = new System.Drawing.Point(66, 229);
            this.Sobrenome.Margin = new System.Windows.Forms.Padding(2);
            this.Sobrenome.Name = "Sobrenome";
            this.Sobrenome.Size = new System.Drawing.Size(127, 20);
            this.Sobrenome.TabIndex = 23;
            // 
            // PrimeiroNome
            // 
            this.PrimeiroNome.Location = new System.Drawing.Point(66, 160);
            this.PrimeiroNome.Margin = new System.Windows.Forms.Padding(2);
            this.PrimeiroNome.Name = "PrimeiroNome";
            this.PrimeiroNome.Size = new System.Drawing.Size(127, 20);
            this.PrimeiroNome.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(500, 144);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Email";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(298, 277);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Telefone";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(298, 214);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Data de Nascimento";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(298, 144);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "CPF";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 277);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Genero";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 214);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Sobrenome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 144);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Primeiro Nome";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(10, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(687, 63);
            this.label1.TabIndex = 19;
            this.label1.Text = "Editar Cliente";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Btn_Editar
            // 
            this.Btn_Editar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Btn_Editar.Location = new System.Drawing.Point(556, 353);
            this.Btn_Editar.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Editar.Name = "Btn_Editar";
            this.Btn_Editar.Size = new System.Drawing.Size(70, 28);
            this.Btn_Editar.TabIndex = 35;
            this.Btn_Editar.Text = "Editar";
            this.Btn_Editar.UseVisualStyleBackColor = false;
            this.Btn_Editar.Click += new System.EventHandler(this.Btn_Editar_Click);
            // 
            // EditarClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 403);
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
            this.Controls.Add(this.Btn_Editar);
            this.Name = "EditarClienteForm";
            this.Text = "EditarClienteForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DataDeNascimento;
        private System.Windows.Forms.Button Btn_Limpar;
        private System.Windows.Forms.MaskedTextBox Telefone;
        private System.Windows.Forms.MaskedTextBox CPF;
        private System.Windows.Forms.ComboBox Genero;
        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.TextBox Sobrenome;
        private System.Windows.Forms.TextBox PrimeiroNome;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_Editar;
    }
}