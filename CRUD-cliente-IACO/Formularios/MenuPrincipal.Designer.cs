namespace CRUD_cliente_IACO.Formularios
{
    partial class MenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AdicionarCliente = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.VisualizarClientesCadastrados = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AdicionarCliente)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VisualizarClientesCadastrados)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(460, 63);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gerenciamento de Clientes";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AdicionarCliente);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 104);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adicionar um novo cliente";
            // 
            // AdicionarCliente
            // 
            this.AdicionarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AdicionarCliente.Image = ((System.Drawing.Image)(resources.GetObject("AdicionarCliente.Image")));
            this.AdicionarCliente.Location = new System.Drawing.Point(61, 37);
            this.AdicionarCliente.Name = "AdicionarCliente";
            this.AdicionarCliente.Size = new System.Drawing.Size(59, 50);
            this.AdicionarCliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AdicionarCliente.TabIndex = 0;
            this.AdicionarCliente.TabStop = false;
            this.AdicionarCliente.Click += new System.EventHandler(this.AdicionarCliente_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.VisualizarClientesCadastrados);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(265, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 104);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Visualizar clientes cadastrados";
            // 
            // VisualizarClientesCadastrados
            // 
            this.VisualizarClientesCadastrados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.VisualizarClientesCadastrados.Image = ((System.Drawing.Image)(resources.GetObject("VisualizarClientesCadastrados.Image")));
            this.VisualizarClientesCadastrados.Location = new System.Drawing.Point(70, 37);
            this.VisualizarClientesCadastrados.Name = "VisualizarClientesCadastrados";
            this.VisualizarClientesCadastrados.Size = new System.Drawing.Size(59, 50);
            this.VisualizarClientesCadastrados.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.VisualizarClientesCadastrados.TabIndex = 0;
            this.VisualizarClientesCadastrados.TabStop = false;
            this.VisualizarClientesCadastrados.Click += new System.EventHandler(this.VisualizarClientesCadastrados_Click);
            // 
            // GestaoDeClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "GestaoDeClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestão de Clientes";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AdicionarCliente)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VisualizarClientesCadastrados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox AdicionarCliente;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox VisualizarClientesCadastrados;
    }
}