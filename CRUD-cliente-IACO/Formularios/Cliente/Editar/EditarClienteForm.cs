using CRUD_cliente_IACO.Enums;
using CRUD_cliente_IACO.Factories;
using CRUD_cliente_IACO.Repositorios;
using CRUD_cliente_IACO.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CRUD_cliente_IACO.Formularios.Cliente.Editar
{
    public partial class EditarClienteForm : Form
    {

        private readonly IClienteRepository _clienteRepository;

        public Modelos.Cliente clienteAtual;
        public EditarClienteForm(
            Modelos.Cliente cliente,
            IClienteRepository clienteRepository = null)
        {
            InitializeComponent();
            clienteAtual = cliente;
            PreencherCampos();
            _clienteRepository = clienteRepository;
        }


        private void PreencherCampos()
        {
            Genero.DataSource = Enum.GetValues(typeof(GenerosEnum));

            PrimeiroNome.Text = clienteAtual.PrimeiroNome;
            Sobrenome.Text = clienteAtual.Sobrenome;
            CPF.Text = clienteAtual.CPF;
            Email.Text = clienteAtual.Email;
            Telefone.Text = clienteAtual.Telefone;
            Genero.SelectedItem = clienteAtual.Genero;
            DataDeNascimento.Value = clienteAtual.DataNascimento;

        }

        private void Btn_Editar_Click(object sender, EventArgs e)
        {

            var clienteAtualizado = new Modelos.Cliente
            {
                PrimeiroNome = PrimeiroNome.Text,
                Sobrenome = Sobrenome.Text,
                Email = Email.Text,
                Telefone = Telefone.Text,
                CPF = CPF.Text,
                DataNascimento = DataDeNascimento.Value,
                Genero = (GenerosEnum)Enum.Parse(typeof(GenerosEnum), Genero.SelectedItem.ToString())
            };

            _clienteRepository.AtualizarCliente(clienteAtualizado);
            this.Close();
     
        }
    }
}
