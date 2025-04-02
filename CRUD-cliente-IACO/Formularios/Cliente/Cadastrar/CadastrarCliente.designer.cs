using System.Drawing;
using System.Windows.Forms;

namespace CRUD_clientes_IACO
{
    partial class CadastrarCliente
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            textBox3 = new TextBox();
            comboBox1 = new ComboBox();
            panel1_endereco = new Panel();
            btn_proximo = new Button();
            btn_voltar = new Button();
            label16 = new Label();
            textBox13 = new TextBox();
            label15 = new Label();
            textBox12 = new TextBox();
            label13 = new Label();
            textBox10 = new TextBox();
            label14 = new Label();
            textBox11 = new TextBox();
            label10 = new Label();
            label12 = new Label();
            textBox9 = new TextBox();
            label11 = new Label();
            textBox8 = new TextBox();
            button1 = new Button();
            panel1_endereco.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ControlLight;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(776, 69);
            label1.TabIndex = 0;
            label1.Text = "Cadastrar Cliente";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 147);
            label2.Name = "label2";
            label2.Size = new Size(110, 20);
            label2.TabIndex = 1;
            label2.Text = "Primeiro Nome";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(72, 232);
            label3.Name = "label3";
            label3.Size = new Size(86, 20);
            label3.TabIndex = 3;
            label3.Text = "Sobrenome";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(72, 314);
            label4.Name = "label4";
            label4.Size = new Size(57, 20);
            label4.TabIndex = 5;
            label4.Text = "Genero";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(281, 147);
            label5.Name = "label5";
            label5.Size = new Size(71, 20);
            label5.TabIndex = 7;
            label5.Text = "Endereço";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(281, 232);
            label6.Name = "label6";
            label6.Size = new Size(33, 20);
            label6.TabIndex = 9;
            label6.Text = "CPF";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(281, 314);
            label7.Name = "label7";
            label7.Size = new Size(145, 20);
            label7.TabIndex = 11;
            label7.Text = "Data de Nascimento";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(496, 147);
            label8.Name = "label8";
            label8.Size = new Size(66, 20);
            label8.TabIndex = 13;
            label8.Text = "Telefone";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(496, 232);
            label9.Name = "label9";
            label9.Size = new Size(46, 20);
            label9.TabIndex = 15;
            label9.Text = "Email";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(72, 170);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(72, 255);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 4;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(281, 255);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 10;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(281, 337);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(125, 27);
            textBox5.TabIndex = 12;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(496, 170);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(125, 27);
            textBox6.TabIndex = 14;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(496, 255);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(125, 27);
            textBox7.TabIndex = 16;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(281, 170);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 8;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(72, 337);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(125, 28);
            comboBox1.TabIndex = 6;
            // 
            // panel1_endereco
            // 
            panel1_endereco.Controls.Add(btn_proximo);
            panel1_endereco.Controls.Add(btn_voltar);
            panel1_endereco.Controls.Add(label16);
            panel1_endereco.Controls.Add(textBox13);
            panel1_endereco.Controls.Add(label15);
            panel1_endereco.Controls.Add(textBox12);
            panel1_endereco.Controls.Add(label13);
            panel1_endereco.Controls.Add(textBox10);
            panel1_endereco.Controls.Add(label14);
            panel1_endereco.Controls.Add(textBox11);
            panel1_endereco.Controls.Add(label10);
            panel1_endereco.Controls.Add(label12);
            panel1_endereco.Controls.Add(textBox9);
            panel1_endereco.Controls.Add(label11);
            panel1_endereco.Controls.Add(textBox8);
            panel1_endereco.Location = new Point(46, 81);
            panel1_endereco.Name = "panel1_endereco";
            panel1_endereco.Size = new Size(609, 399);
            panel1_endereco.TabIndex = 18;
            // 
            // btn_proximo
            // 
            btn_proximo.Location = new Point(433, 337);
            btn_proximo.Name = "btn_proximo";
            btn_proximo.Size = new Size(94, 29);
            btn_proximo.TabIndex = 52;
            btn_proximo.Text = "Próximo";
            btn_proximo.UseVisualStyleBackColor = true;
            btn_proximo.Click += btn_proximo_Click;
            // 
            // btn_voltar
            // 
            btn_voltar.Location = new Point(313, 337);
            btn_voltar.Name = "btn_voltar";
            btn_voltar.Size = new Size(94, 29);
            btn_voltar.TabIndex = 51;
            btn_voltar.Text = "Voltar";
            btn_voltar.UseVisualStyleBackColor = true;
            btn_voltar.Click += btn_voltar_Click;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(402, 218);
            label16.Name = "label16";
            label16.Size = new Size(54, 20);
            label16.TabIndex = 29;
            label16.Text = "Estado";
            // 
            // textBox13
            // 
            textBox13.Location = new Point(402, 241);
            textBox13.Name = "textBox13";
            textBox13.Size = new Size(125, 27);
            textBox13.TabIndex = 30;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(402, 134);
            label15.Name = "label15";
            label15.Size = new Size(56, 20);
            label15.TabIndex = 27;
            label15.Text = "Cidade";
            // 
            // textBox12
            // 
            textBox12.Location = new Point(402, 157);
            textBox12.Name = "textBox12";
            textBox12.Size = new Size(125, 27);
            textBox12.TabIndex = 28;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(39, 218);
            label13.Name = "label13";
            label13.Size = new Size(34, 20);
            label13.TabIndex = 21;
            label13.Text = "Rua";
            // 
            // textBox10
            // 
            textBox10.Location = new Point(39, 241);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(125, 27);
            textBox10.TabIndex = 22;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(210, 218);
            label14.Name = "label14";
            label14.Size = new Size(49, 20);
            label14.TabIndex = 25;
            label14.Text = "Bairro";
            // 
            // textBox11
            // 
            textBox11.Location = new Point(210, 241);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(125, 27);
            textBox11.TabIndex = 26;
            // 
            // label10
            // 
            label10.BackColor = SystemColors.ControlLight;
            label10.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label10.Location = new Point(3, 0);
            label10.Name = "label10";
            label10.Size = new Size(612, 76);
            label10.TabIndex = 50;
            label10.Text = "Endereço";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F);
            label12.Location = new Point(210, 134);
            label12.Name = "label12";
            label12.Size = new Size(138, 20);
            label12.TabIndex = 23;
            label12.Text = "Número Residencia";
            // 
            // textBox9
            // 
            textBox9.Location = new Point(39, 157);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(125, 27);
            textBox9.TabIndex = 20;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(39, 134);
            label11.Name = "label11";
            label11.Size = new Size(34, 20);
            label11.TabIndex = 19;
            label11.Text = "CEP";
            // 
            // textBox8
            // 
            textBox8.Location = new Point(210, 157);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(125, 27);
            textBox8.TabIndex = 24;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Window;
            button1.Location = new Point(527, 418);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 19;
            button1.Text = "Próximo";
            button1.UseVisualStyleBackColor = false;
            // 
            // CadastrarCliente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(713, 492);
            Controls.Add(panel1_endereco);
            Controls.Add(comboBox1);
            Controls.Add(textBox7);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "CadastrarCliente";
            Text = "Form1";
            Load += CadastrarCliente_Load;
            panel1_endereco.ResumeLayout(false);
            panel1_endereco.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox3;
        private ComboBox comboBox1;
        private Panel panel1_endereco;
        private Label label11;
        private TextBox textBox8;
        private Label label12;
        private TextBox textBox9;
        private Label label13;
        private TextBox textBox10;
        private Label label14;
        private TextBox textBox11;
        private Label label10;
        private Label label16;
        private TextBox textBox13;
        private Label label15;
        private TextBox textBox12;
        private Button btn_proximo;
        private Button btn_voltar;
        private Button button1;
    }
}
