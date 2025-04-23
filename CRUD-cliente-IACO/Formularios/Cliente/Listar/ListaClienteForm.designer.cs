namespace CRUD_cliente_IACO.Formularios.Cliente.Listar
{
    partial class ListaClienteForm
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
            this.ListagemDeClientes = new System.Windows.Forms.Label();
            this.clientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewClientes = new System.Windows.Forms.DataGridView();
            this.campoFiltro = new System.Windows.Forms.TextBox();
            this.labelCampoFiltro = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // ListagemDeClientes
            // 
            this.ListagemDeClientes.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ListagemDeClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListagemDeClientes.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ListagemDeClientes.Location = new System.Drawing.Point(17, 18);
            this.ListagemDeClientes.Name = "ListagemDeClientes";
            this.ListagemDeClientes.Padding = new System.Windows.Forms.Padding(10);
            this.ListagemDeClientes.Size = new System.Drawing.Size(566, 49);
            this.ListagemDeClientes.TabIndex = 0;
            this.ListagemDeClientes.Text = "LISTAGEM DE CLIENTES";
            // 
            // clientesBindingSource
            // 
            this.clientesBindingSource.DataMember = "Clientes";
            // 
            // dataGridViewClientes
            // 
            this.dataGridViewClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClientes.Location = new System.Drawing.Point(17, 140);
            this.dataGridViewClientes.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewClientes.Name = "dataGridViewClientes";
            this.dataGridViewClientes.RowTemplate.Height = 24;
            this.dataGridViewClientes.Size = new System.Drawing.Size(566, 205);
            this.dataGridViewClientes.TabIndex = 1;
            this.dataGridViewClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClientes_CellClick);
            // 
            // campoFiltro
            // 
            this.campoFiltro.Location = new System.Drawing.Point(17, 100);
            this.campoFiltro.Name = "campoFiltro";
            this.campoFiltro.Size = new System.Drawing.Size(165, 20);
            this.campoFiltro.TabIndex = 2;
            this.campoFiltro.TextChanged += new System.EventHandler(this.campoFiltro_TextChanged);
            // 
            // labelCampoFiltro
            // 
            this.labelCampoFiltro.AutoSize = true;
            this.labelCampoFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCampoFiltro.Location = new System.Drawing.Point(14, 84);
            this.labelCampoFiltro.Name = "labelCampoFiltro";
            this.labelCampoFiltro.Size = new System.Drawing.Size(168, 13);
            this.labelCampoFiltro.TabIndex = 3;
            this.labelCampoFiltro.Text = "Encontre pelo primeiro nome";
            // 
            // ListaClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 356);
            this.Controls.Add(this.labelCampoFiltro);
            this.Controls.Add(this.campoFiltro);
            this.Controls.Add(this.dataGridViewClientes);
            this.Controls.Add(this.ListagemDeClientes);
            this.Name = "ListaClienteForm";
            this.Text = "Listagem de clientes";
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ListagemDeClientes;
        private System.Windows.Forms.BindingSource clientesBindingSource;
        private System.Windows.Forms.DataGridView dataGridViewClientes;
        private System.Windows.Forms.TextBox campoFiltro;
        private System.Windows.Forms.Label labelCampoFiltro;
    }
}