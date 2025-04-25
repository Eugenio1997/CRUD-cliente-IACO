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
            this.primeiroNomeFiltro = new System.Windows.Forms.TextBox();
            this.FiltroPrimeiroNomeLabel = new System.Windows.Forms.Label();
            this.GeneroFiltro = new System.Windows.Forms.ComboBox();
            this.Filtros = new System.Windows.Forms.GroupBox();
            this.dateTimePickerFiltro = new System.Windows.Forms.DateTimePicker();
            this.FiltroGeneroLabel = new System.Windows.Forms.Label();
            this.numeroRegistrosLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientes)).BeginInit();
            this.Filtros.SuspendLayout();
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
            this.dataGridViewClientes.Location = new System.Drawing.Point(17, 154);
            this.dataGridViewClientes.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewClientes.Name = "dataGridViewClientes";
            this.dataGridViewClientes.RowTemplate.Height = 24;
            this.dataGridViewClientes.Size = new System.Drawing.Size(566, 191);
            this.dataGridViewClientes.TabIndex = 6;
            this.dataGridViewClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClientes_CellClick);
            // 
            // primeiroNomeFiltro
            // 
            this.primeiroNomeFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.primeiroNomeFiltro.Location = new System.Drawing.Point(6, 52);
            this.primeiroNomeFiltro.Name = "primeiroNomeFiltro";
            this.primeiroNomeFiltro.Size = new System.Drawing.Size(121, 20);
            this.primeiroNomeFiltro.TabIndex = 2;
            this.primeiroNomeFiltro.TextChanged += new System.EventHandler(this.primeiroNomeFiltro_TextChanged);
            // 
            // FiltroPrimeiroNomeLabel
            // 
            this.FiltroPrimeiroNomeLabel.AutoSize = true;
            this.FiltroPrimeiroNomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FiltroPrimeiroNomeLabel.Location = new System.Drawing.Point(3, 36);
            this.FiltroPrimeiroNomeLabel.Name = "FiltroPrimeiroNomeLabel";
            this.FiltroPrimeiroNomeLabel.Size = new System.Drawing.Size(86, 13);
            this.FiltroPrimeiroNomeLabel.TabIndex = 1;
            this.FiltroPrimeiroNomeLabel.Text = "Primeiro nome";
            // 
            // GeneroFiltro
            // 
            this.GeneroFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GeneroFiltro.FormattingEnabled = true;
            this.GeneroFiltro.Location = new System.Drawing.Point(144, 50);
            this.GeneroFiltro.Name = "GeneroFiltro";
            this.GeneroFiltro.Size = new System.Drawing.Size(121, 21);
            this.GeneroFiltro.TabIndex = 4;
            this.GeneroFiltro.SelectedIndexChanged += new System.EventHandler(this.GeneroFiltro_SelectedIndexChanged);
            // 
            // Filtros
            // 
            this.Filtros.Controls.Add(this.dateTimePickerFiltro);
            this.Filtros.Controls.Add(this.FiltroGeneroLabel);
            this.Filtros.Controls.Add(this.GeneroFiltro);
            this.Filtros.Controls.Add(this.FiltroPrimeiroNomeLabel);
            this.Filtros.Controls.Add(this.primeiroNomeFiltro);
            this.Filtros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filtros.Location = new System.Drawing.Point(17, 70);
            this.Filtros.Name = "Filtros";
            this.Filtros.Size = new System.Drawing.Size(566, 79);
            this.Filtros.TabIndex = 5;
            this.Filtros.TabStop = false;
            this.Filtros.Text = "Filtros";
            // 
            // dateTimePickerFiltro
            // 
            this.dateTimePickerFiltro.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFiltro.Location = new System.Drawing.Point(291, 52);
            this.dateTimePickerFiltro.Name = "dateTimePickerFiltro";
            this.dateTimePickerFiltro.Size = new System.Drawing.Size(200, 26);
            this.dateTimePickerFiltro.TabIndex = 5;
            // 
            // FiltroGeneroLabel
            // 
            this.FiltroGeneroLabel.AutoSize = true;
            this.FiltroGeneroLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FiltroGeneroLabel.Location = new System.Drawing.Point(141, 34);
            this.FiltroGeneroLabel.Name = "FiltroGeneroLabel";
            this.FiltroGeneroLabel.Size = new System.Drawing.Size(48, 13);
            this.FiltroGeneroLabel.TabIndex = 3;
            this.FiltroGeneroLabel.Text = "Genero";
            // 
            // numeroRegistrosLabel
            // 
            this.numeroRegistrosLabel.AutoSize = true;
            this.numeroRegistrosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroRegistrosLabel.Location = new System.Drawing.Point(536, 355);
            this.numeroRegistrosLabel.Name = "numeroRegistrosLabel";
            this.numeroRegistrosLabel.Size = new System.Drawing.Size(51, 16);
            this.numeroRegistrosLabel.TabIndex = 6;
            this.numeroRegistrosLabel.Text = "label1";
            // 
            // ListaClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 379);
            this.Controls.Add(this.numeroRegistrosLabel);
            this.Controls.Add(this.dataGridViewClientes);
            this.Controls.Add(this.ListagemDeClientes);
            this.Controls.Add(this.Filtros);
            this.Name = "ListaClienteForm";
            this.Text = "Listagem de clientes";
            this.Load += new System.EventHandler(this.ListaClienteForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientes)).EndInit();
            this.Filtros.ResumeLayout(false);
            this.Filtros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ListagemDeClientes;
        private System.Windows.Forms.BindingSource clientesBindingSource;
        private System.Windows.Forms.DataGridView dataGridViewClientes;
        private System.Windows.Forms.TextBox primeiroNomeFiltro;
        private System.Windows.Forms.Label FiltroPrimeiroNomeLabel;
        private System.Windows.Forms.ComboBox GeneroFiltro;
        private System.Windows.Forms.GroupBox Filtros;
        private System.Windows.Forms.Label FiltroGeneroLabel;
        private System.Windows.Forms.DateTimePicker dateTimePickerFiltro;
        private System.Windows.Forms.Label numeroRegistrosLabel;
    }
}