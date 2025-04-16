namespace CRUD_cliente_IACO.Formularios.Cliente.Cadastrar
{
    partial class CadastroEnderecoClienteForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Rua = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.NResidencia = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Btn_Cadastrar = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.CEP = new System.Windows.Forms.MaskedTextBox();
            this.Estado = new System.Windows.Forms.ComboBox();
            this.Cidade = new System.Windows.Forms.ComboBox();
            this.Bairro = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(687, 63);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cadastrar Endereço";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "CEP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Estado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(264, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cidade";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(264, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Bairro";
            // 
            // Rua
            // 
            this.Rua.Location = new System.Drawing.Point(482, 129);
            this.Rua.Name = "Rua";
            this.Rua.Size = new System.Drawing.Size(127, 20);
            this.Rua.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(479, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Rua";
            // 
            // NResidencia
            // 
            this.NResidencia.Location = new System.Drawing.Point(482, 248);
            this.NResidencia.Name = "NResidencia";
            this.NResidencia.Size = new System.Drawing.Size(127, 20);
            this.NResidencia.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(479, 232);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Nº Residencia";
            // 
            // Btn_Cadastrar
            // 
            this.Btn_Cadastrar.Location = new System.Drawing.Point(539, 333);
            this.Btn_Cadastrar.Name = "Btn_Cadastrar";
            this.Btn_Cadastrar.Size = new System.Drawing.Size(70, 28);
            this.Btn_Cadastrar.TabIndex = 15;
            this.Btn_Cadastrar.Text = "Cadastrar";
            this.Btn_Cadastrar.UseVisualStyleBackColor = true;
            this.Btn_Cadastrar.Click += new System.EventHandler(this.Btn_Cadastrar_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnVoltar.Location = new System.Drawing.Point(441, 333);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(78, 28);
            this.btnVoltar.TabIndex = 14;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // CEP
            // 
            this.CEP.Location = new System.Drawing.Point(49, 129);
            this.CEP.Mask = "00000-000";
            this.CEP.Name = "CEP";
            this.CEP.Size = new System.Drawing.Size(127, 20);
            this.CEP.TabIndex = 3;
            this.CEP.TextChanged += new System.EventHandler(this.CEP_TextChanged);
            this.CEP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CEP_KeyPress);
            this.CEP.Leave += new System.EventHandler(this.CEP_Leave);
            // 
            // Estado
            // 
            this.Estado.FormattingEnabled = true;
            this.Estado.Location = new System.Drawing.Point(49, 248);
            this.Estado.Name = "Estado";
            this.Estado.Size = new System.Drawing.Size(127, 21);
            this.Estado.TabIndex = 5;
            // 
            // Cidade
            // 
            this.Cidade.FormattingEnabled = true;
            this.Cidade.Location = new System.Drawing.Point(267, 129);
            this.Cidade.Name = "Cidade";
            this.Cidade.Size = new System.Drawing.Size(127, 21);
            this.Cidade.TabIndex = 7;
            // 
            // Bairro
            // 
            this.Bairro.Location = new System.Drawing.Point(267, 249);
            this.Bairro.Name = "Bairro";
            this.Bairro.Size = new System.Drawing.Size(127, 20);
            this.Bairro.TabIndex = 9;
            // 
            // CadastroEnderecoClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 403);
            this.Controls.Add(this.Bairro);
            this.Controls.Add(this.Cidade);
            this.Controls.Add(this.Estado);
            this.Controls.Add(this.CEP);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.Btn_Cadastrar);
            this.Controls.Add(this.NResidencia);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Rua);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CadastroEnderecoClienteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Endereço";
            this.Load += new System.EventHandler(this.CadastroEnderecoClienteForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Rua;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox NResidencia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Btn_Cadastrar;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.MaskedTextBox CEP;
        private System.Windows.Forms.ComboBox Estado;
        private System.Windows.Forms.ComboBox Cidade;
        private System.Windows.Forms.TextBox Bairro;
        private System.Windows.Forms.Timer timer1;
    }
}