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
            this.btnUltima = new System.Windows.Forms.Button();
            this.btnProxima = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnPrimeira = new System.Windows.Forms.Button();
            this.lblTotalRegistros = new System.Windows.Forms.Label();
            this.lblTotalRegistroValor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPaginaAtual = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotalPaginas = new System.Windows.Forms.Label();
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
            this.ListagemDeClientes.Location = new System.Drawing.Point(23, 22);
            this.ListagemDeClientes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ListagemDeClientes.Name = "ListagemDeClientes";
            this.ListagemDeClientes.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.ListagemDeClientes.Size = new System.Drawing.Size(755, 60);
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
            this.dataGridViewClientes.Location = new System.Drawing.Point(23, 336);
            this.dataGridViewClientes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewClientes.Name = "dataGridViewClientes";
            this.dataGridViewClientes.RowTemplate.Height = 24;
            this.dataGridViewClientes.Size = new System.Drawing.Size(755, 171);
            this.dataGridViewClientes.TabIndex = 11;
            this.dataGridViewClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClientes_CellClick);
            // 
            // PrimeiroNomeFiltro
            // 
            this.PrimeiroNomeFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrimeiroNomeFiltro.Location = new System.Drawing.Point(29, 59);
            this.PrimeiroNomeFiltro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PrimeiroNomeFiltro.Name = "PrimeiroNomeFiltro";
            this.PrimeiroNomeFiltro.Size = new System.Drawing.Size(160, 23);
            this.PrimeiroNomeFiltro.TabIndex = 2;
            // 
            // FiltroPrimeiroNomeLabel
            // 
            this.FiltroPrimeiroNomeLabel.AutoSize = true;
            this.FiltroPrimeiroNomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FiltroPrimeiroNomeLabel.Location = new System.Drawing.Point(25, 39);
            this.FiltroPrimeiroNomeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FiltroPrimeiroNomeLabel.Name = "FiltroPrimeiroNomeLabel";
            this.FiltroPrimeiroNomeLabel.Size = new System.Drawing.Size(112, 17);
            this.FiltroPrimeiroNomeLabel.TabIndex = 1;
            this.FiltroPrimeiroNomeLabel.Text = "Primeiro nome";
            // 
            // GeneroFiltro
            // 
            this.GeneroFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GeneroFiltro.FormattingEnabled = true;
            this.GeneroFiltro.Location = new System.Drawing.Point(525, 58);
            this.GeneroFiltro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GeneroFiltro.Name = "GeneroFiltro";
            this.GeneroFiltro.Size = new System.Drawing.Size(193, 25);
            this.GeneroFiltro.TabIndex = 6;
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
            this.Filtros.Location = new System.Drawing.Point(23, 86);
            this.Filtros.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Filtros.Name = "Filtros";
            this.Filtros.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Filtros.Size = new System.Drawing.Size(755, 198);
            this.Filtros.TabIndex = 5;
            this.Filtros.TabStop = false;
            this.Filtros.Text = "Filtros";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Data de Nascimento";
            // 
            // BtnLimparFiltros
            // 
            this.BtnLimparFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLimparFiltros.Location = new System.Drawing.Point(455, 156);
            this.BtnLimparFiltros.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnLimparFiltros.Name = "BtnLimparFiltros";
            this.BtnLimparFiltros.Size = new System.Drawing.Size(147, 34);
            this.BtnLimparFiltros.TabIndex = 9;
            this.BtnLimparFiltros.Text = "Limpar Filtros";
            this.BtnLimparFiltros.UseVisualStyleBackColor = true;
            this.BtnLimparFiltros.Click += new System.EventHandler(this.Btn_LimparFiltros_Click);
            // 
            // SobrenomeFiltro
            // 
            this.SobrenomeFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SobrenomeFiltro.Location = new System.Drawing.Point(296, 59);
            this.SobrenomeFiltro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SobrenomeFiltro.Name = "SobrenomeFiltro";
            this.SobrenomeFiltro.Size = new System.Drawing.Size(160, 23);
            this.SobrenomeFiltro.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(292, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sobrenome";
            // 
            // BtnBuscarClientes
            // 
            this.BtnBuscarClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscarClientes.Location = new System.Drawing.Point(621, 156);
            this.BtnBuscarClientes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnBuscarClientes.Name = "BtnBuscarClientes";
            this.BtnBuscarClientes.Size = new System.Drawing.Size(100, 34);
            this.BtnBuscarClientes.TabIndex = 10;
            this.BtnBuscarClientes.Text = "Buscar";
            this.BtnBuscarClientes.UseVisualStyleBackColor = true;
            this.BtnBuscarClientes.Click += new System.EventHandler(this.Btn_BuscarClientes_Click);
            // 
            // DataNascimentoFiltro
            // 
            this.DataNascimentoFiltro.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataNascimentoFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.DataNascimentoFiltro.Location = new System.Drawing.Point(29, 118);
            this.DataNascimentoFiltro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DataNascimentoFiltro.Name = "DataNascimentoFiltro";
            this.DataNascimentoFiltro.Size = new System.Drawing.Size(355, 23);
            this.DataNascimentoFiltro.TabIndex = 8;
            // 
            // FiltroGeneroLabel
            // 
            this.FiltroGeneroLabel.AutoSize = true;
            this.FiltroGeneroLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FiltroGeneroLabel.Location = new System.Drawing.Point(521, 38);
            this.FiltroGeneroLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FiltroGeneroLabel.Name = "FiltroGeneroLabel";
            this.FiltroGeneroLabel.Size = new System.Drawing.Size(62, 17);
            this.FiltroGeneroLabel.TabIndex = 5;
            this.FiltroGeneroLabel.Text = "Genero";
            // 
            // btnUltima
            // 
            this.btnUltima.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnUltima.Location = new System.Drawing.Point(678, 528);
            this.btnUltima.Margin = new System.Windows.Forms.Padding(4);
            this.btnUltima.Name = "btnUltima";
            this.btnUltima.Size = new System.Drawing.Size(100, 34);
            this.btnUltima.TabIndex = 12;
            this.btnUltima.Text = "Última";
            this.btnUltima.UseVisualStyleBackColor = true;
            this.btnUltima.Click += new System.EventHandler(this.btnUltimo_Click);
            // 
            // btnProxima
            // 
            this.btnProxima.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnProxima.Location = new System.Drawing.Point(571, 528);
            this.btnProxima.Name = "btnProxima";
            this.btnProxima.Size = new System.Drawing.Size(100, 34);
            this.btnProxima.TabIndex = 13;
            this.btnProxima.Text = "Próxima";
            this.btnProxima.UseVisualStyleBackColor = true;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnVoltar.Location = new System.Drawing.Point(465, 528);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(100, 34);
            this.btnVoltar.TabIndex = 14;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            // 
            // btnPrimeira
            // 
            this.btnPrimeira.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnPrimeira.Location = new System.Drawing.Point(359, 528);
            this.btnPrimeira.Name = "btnPrimeira";
            this.btnPrimeira.Size = new System.Drawing.Size(100, 34);
            this.btnPrimeira.TabIndex = 15;
            this.btnPrimeira.Text = "Primeira";
            this.btnPrimeira.UseVisualStyleBackColor = true;
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.AutoSize = true;
            this.lblTotalRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTotalRegistros.Location = new System.Drawing.Point(26, 302);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(170, 20);
            this.lblTotalRegistros.TabIndex = 16;
            this.lblTotalRegistros.Text = "Total de Registros:";
            // 
            // lblTotalRegistroValor
            // 
            this.lblTotalRegistroValor.AutoSize = true;
            this.lblTotalRegistroValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTotalRegistroValor.Location = new System.Drawing.Point(202, 302);
            this.lblTotalRegistroValor.Name = "lblTotalRegistroValor";
            this.lblTotalRegistroValor.Size = new System.Drawing.Size(19, 20);
            this.lblTotalRegistroValor.TabIndex = 11;
            this.lblTotalRegistroValor.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(602, 302);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Página";
            // 
            // lblPaginaAtual
            // 
            this.lblPaginaAtual.AutoSize = true;
            this.lblPaginaAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblPaginaAtual.Location = new System.Drawing.Point(674, 302);
            this.lblPaginaAtual.Name = "lblPaginaAtual";
            this.lblPaginaAtual.Size = new System.Drawing.Size(19, 20);
            this.lblPaginaAtual.TabIndex = 18;
            this.lblPaginaAtual.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(699, 302);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "de";
            // 
            // lblTotalPaginas
            // 
            this.lblTotalPaginas.AutoSize = true;
            this.lblTotalPaginas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTotalPaginas.Location = new System.Drawing.Point(734, 302);
            this.lblTotalPaginas.Name = "lblTotalPaginas";
            this.lblTotalPaginas.Size = new System.Drawing.Size(19, 20);
            this.lblTotalPaginas.TabIndex = 20;
            this.lblTotalPaginas.Text = "0";
            // 
            // ListaClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 574);
            this.Controls.Add(this.lblTotalPaginas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblPaginaAtual);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTotalRegistroValor);
            this.Controls.Add(this.lblTotalRegistros);
            this.Controls.Add(this.btnPrimeira);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnProxima);
            this.Controls.Add(this.btnUltima);
            this.Controls.Add(this.dataGridViewClientes);
            this.Controls.Add(this.ListagemDeClientes);
            this.Controls.Add(this.Filtros);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.Button BtnBuscarClientes;
        private System.Windows.Forms.TextBox SobrenomeFiltro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnLimparFiltros;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUltima;
        private System.Windows.Forms.Button btnProxima;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnPrimeira;
        private System.Windows.Forms.Label lblTotalRegistros;
        private System.Windows.Forms.Label lblTotalRegistroValor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPaginaAtual;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotalPaginas;
    }
}