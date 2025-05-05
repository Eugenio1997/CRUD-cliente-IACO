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
            this.PrimeiroNomeFiltro = new System.Windows.Forms.TextBox();
            this.FiltroPrimeiroNomeLabel = new System.Windows.Forms.Label();
            this.GeneroFiltro = new System.Windows.Forms.ComboBox();
            this.Filtros = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnLimparFiltros = new System.Windows.Forms.Button();
            this.SobrenomeFiltro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnBuscarClientes = new System.Windows.Forms.Button();
            this.DataNascimentoFiltro = new System.Windows.Forms.DateTimePicker();
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
            this.dataGridViewClientes.Location = new System.Drawing.Point(17, 236);
            this.dataGridViewClientes.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewClientes.Name = "dataGridViewClientes";
            this.dataGridViewClientes.RowTemplate.Height = 24;
            this.dataGridViewClientes.Size = new System.Drawing.Size(566, 191);
            this.dataGridViewClientes.TabIndex = 11;
            this.dataGridViewClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClientes_CellClick);
            // 
            // PrimeiroNomeFiltro
            // 
            this.PrimeiroNomeFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrimeiroNomeFiltro.Location = new System.Drawing.Point(22, 48);
            this.PrimeiroNomeFiltro.Name = "PrimeiroNomeFiltro";
            this.PrimeiroNomeFiltro.Size = new System.Drawing.Size(121, 20);
            this.PrimeiroNomeFiltro.TabIndex = 2;
            // 
            // FiltroPrimeiroNomeLabel
            // 
            this.FiltroPrimeiroNomeLabel.AutoSize = true;
            this.FiltroPrimeiroNomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FiltroPrimeiroNomeLabel.Location = new System.Drawing.Point(19, 32);
            this.FiltroPrimeiroNomeLabel.Name = "FiltroPrimeiroNomeLabel";
            this.FiltroPrimeiroNomeLabel.Size = new System.Drawing.Size(86, 13);
            this.FiltroPrimeiroNomeLabel.TabIndex = 1;
            this.FiltroPrimeiroNomeLabel.Text = "Primeiro nome";
            // 
            // GeneroFiltro
            // 
            this.GeneroFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GeneroFiltro.FormattingEnabled = true;
            this.GeneroFiltro.Location = new System.Drawing.Point(394, 47);
            this.GeneroFiltro.Name = "GeneroFiltro";
            this.GeneroFiltro.Size = new System.Drawing.Size(146, 21);
            this.GeneroFiltro.TabIndex = 6;
            this.GeneroFiltro.SelectedIndexChanged += new System.EventHandler(this.GeneroFiltro_SelectedIndexChanged);
            // 
            // Filtros
            // 
            this.Filtros.Controls.Add(this.label2);
            this.Filtros.Controls.Add(this.BtnLimparFiltros);
            this.Filtros.Controls.Add(this.SobrenomeFiltro);
            this.Filtros.Controls.Add(this.label1);
            this.Filtros.Controls.Add(this.BtnBuscarClientes);
            this.Filtros.Controls.Add(this.DataNascimentoFiltro);
            this.Filtros.Controls.Add(this.FiltroGeneroLabel);
            this.Filtros.Controls.Add(this.GeneroFiltro);
            this.Filtros.Controls.Add(this.FiltroPrimeiroNomeLabel);
            this.Filtros.Controls.Add(this.PrimeiroNomeFiltro);
            this.Filtros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filtros.Location = new System.Drawing.Point(17, 70);
            this.Filtros.Name = "Filtros";
            this.Filtros.Size = new System.Drawing.Size(566, 161);
            this.Filtros.TabIndex = 5;
            this.Filtros.TabStop = false;
            this.Filtros.Text = "Filtros";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Data de Nascimento";
            // 
            // BtnLimparFiltros
            // 
            this.BtnLimparFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLimparFiltros.Location = new System.Drawing.Point(341, 127);
            this.BtnLimparFiltros.Name = "BtnLimparFiltros";
            this.BtnLimparFiltros.Size = new System.Drawing.Size(110, 28);
            this.BtnLimparFiltros.TabIndex = 9;
            this.BtnLimparFiltros.Text = "Limpar Filtros";
            this.BtnLimparFiltros.UseVisualStyleBackColor = true;
            this.BtnLimparFiltros.Click += new System.EventHandler(this.Btn_LimparFiltros_Click);
            // 
            // SobrenomeFiltro
            // 
            this.SobrenomeFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SobrenomeFiltro.Location = new System.Drawing.Point(222, 48);
            this.SobrenomeFiltro.Name = "SobrenomeFiltro";
            this.SobrenomeFiltro.Size = new System.Drawing.Size(121, 20);
            this.SobrenomeFiltro.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(219, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sobrenome";
            // 
            // BtnBuscarClientes
            // 
            this.BtnBuscarClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscarClientes.Location = new System.Drawing.Point(466, 127);
            this.BtnBuscarClientes.Name = "BtnBuscarClientes";
            this.BtnBuscarClientes.Size = new System.Drawing.Size(75, 28);
            this.BtnBuscarClientes.TabIndex = 10;
            this.BtnBuscarClientes.Text = "Buscar";
            this.BtnBuscarClientes.UseVisualStyleBackColor = true;
            this.BtnBuscarClientes.Click += new System.EventHandler(this.Btn_BuscarClientes_Click);
            // 
            // DataNascimentoFiltro
            // 
            this.DataNascimentoFiltro.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataNascimentoFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.DataNascimentoFiltro.Location = new System.Drawing.Point(22, 96);
            this.DataNascimentoFiltro.Name = "DataNascimentoFiltro";
            this.DataNascimentoFiltro.Size = new System.Drawing.Size(267, 20);
            this.DataNascimentoFiltro.TabIndex = 8;
            this.DataNascimentoFiltro.ValueChanged += new System.EventHandler(this.DataNascimentoFiltro_ValueChanged);
            // 
            // FiltroGeneroLabel
            // 
            this.FiltroGeneroLabel.AutoSize = true;
            this.FiltroGeneroLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FiltroGeneroLabel.Location = new System.Drawing.Point(391, 31);
            this.FiltroGeneroLabel.Name = "FiltroGeneroLabel";
            this.FiltroGeneroLabel.Size = new System.Drawing.Size(48, 13);
            this.FiltroGeneroLabel.TabIndex = 5;
            this.FiltroGeneroLabel.Text = "Genero";
            // 
            // numeroRegistrosLabel
            // 
            this.numeroRegistrosLabel.AutoSize = true;
            this.numeroRegistrosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroRegistrosLabel.Location = new System.Drawing.Point(532, 441);
            this.numeroRegistrosLabel.Name = "numeroRegistrosLabel";
            this.numeroRegistrosLabel.Size = new System.Drawing.Size(51, 16);
            this.numeroRegistrosLabel.TabIndex = 12;
            this.numeroRegistrosLabel.Text = "label1";
            // 
            // ListaClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 466);
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
        private System.Windows.Forms.TextBox PrimeiroNomeFiltro;
        private System.Windows.Forms.Label FiltroPrimeiroNomeLabel;
        private System.Windows.Forms.ComboBox GeneroFiltro;
        private System.Windows.Forms.GroupBox Filtros;
        private System.Windows.Forms.Label FiltroGeneroLabel;
        private System.Windows.Forms.DateTimePicker DataNascimentoFiltro;
        private System.Windows.Forms.Label numeroRegistrosLabel;
        private System.Windows.Forms.Button BtnBuscarClientes;
        private System.Windows.Forms.TextBox SobrenomeFiltro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnLimparFiltros;
        private System.Windows.Forms.Label label2;
    }
}