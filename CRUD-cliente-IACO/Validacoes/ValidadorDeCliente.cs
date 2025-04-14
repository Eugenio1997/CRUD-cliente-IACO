using CRUD_cliente_IACO.Enums;
using CRUD_cliente_IACO.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CRUD_cliente_IACO.Validacoes
{
    public static class ValidadorDeCliente
    {
        private static string primeiroNomeRegex = @"^[A-Za-zÀ-ÖØ-öø-ÿ\s'-]{3,50}$";
        private static string sobrenomeRegex = @"^[A-Za-zÀ-ÖØ-öø-ÿ\s'-]{3,50}$";
        private static string emailRegex = @"^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,})+$";
        private static string cpfRegex = @"^\d{11}$"; // sem máscara
        private static string telefoneRegex = @"^\d{10,11}$"; // 10 ou 11 dígitos (sem máscara)

        
        public static void ValidarPrimeiroNome_KeyPress(TextBox txt, KeyPressEventArgs e)
        {
            // Permitir teclas de controle como Backspace, Delete, Tab etc.
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Permitir apenas letras (inclusive acentuadas)
            if (!char.IsLetter(e.KeyChar))
            {
                ToolTipFactory.Configurar(true, ToolTipIcon.Error, "Erro de Validação");
                ToolTipFactory.Show("Somente letras são permitidas!", txt, 2000);
                e.Handled = true; // Bloqueia a tecla
            }
        }

        public static void ValidarSobreNome_KeyPress(TextBox txt, KeyPressEventArgs e)
        {
            // Permitir teclas de controle como Backspace, Delete, Tab etc.
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Permitir apenas letras (inclusive acentuadas)
            if (!char.IsLetter(e.KeyChar))
            {
                // Mostra o tooltip por 2 segundos (2000 ms)
                ToolTipFactory.Configurar(true, ToolTipIcon.Error, "Erro de Validação");
                ToolTipFactory.Show("Somente letras são permitidas!", txt, 2000);
                e.Handled = true; // bloqueia a tecla
            }
        }


        public static void ValidarGenero_SelectedIndexChanged(ComboBox combo)
        {
            if (combo.SelectedIndex == 0 || !Enum.IsDefined(typeof(GenerosEnum), combo.SelectedItem))
            {
                ToolTipFactory.Configurar(true, ToolTipIcon.Error, "Erro de Validação");
                ToolTipFactory.Show("Selecione um gênero válido.", combo, 2000);
                combo.Focus();
                
            }

        }

        public static void ValidarPrimeiroNome_Validating(TextBox txt)
        {
            string valor = txt.Text.Trim();

            if (string.IsNullOrEmpty(valor))
            {
                ToolTipFactory.Configurar(true, ToolTipIcon.Error, "Erro de Validação");
                ToolTipFactory.Show("O campo Sobrenome é obrigatório.", txt, 2000);
                txt.Focus();
             
            }

            else if (!Regex.IsMatch(valor, primeiroNomeRegex))
            {
                ToolTipFactory.Configurar(true, ToolTipIcon.Error, "Erro de Validação");
                ToolTipFactory.Show("O campo Sobrenome deve conter apenas letras (3 a 50 caracteres).", txt, 2000);
                txt.Focus();
               
            }
         
        }


        public static void ValidarSobrenome_Validating(TextBox txt)
        {
            string valor = txt.Text.Trim();

            if (string.IsNullOrEmpty(valor))
            {
                ToolTipFactory.Configurar(true, ToolTipIcon.Error, "Erro de Validação");
                ToolTipFactory.Show("O campo Sobrenome é obrigatório.", txt, 2000);
                txt.Focus();
            }

            else if (!Regex.IsMatch(valor, sobrenomeRegex))
            {
                ToolTipFactory.Configurar(true, ToolTipIcon.Error, "Erro de Validação");
                ToolTipFactory.Show("O campo Sobrenome deve conter apenas letras (3 a 50 caracteres).", txt, 2000);
                txt.Focus();
            }

        }

        public static void ValidarGenero_Validating(ComboBox combo)
        {
            if (combo.SelectedItem == null || !Enum.IsDefined(typeof(GenerosEnum), combo.SelectedItem))
            {
                ToolTipFactory.Configurar(true, ToolTipIcon.Error, "Erro de Validação");
                ToolTipFactory.Show("Selecione um gênero válido.", combo, 2000);
                combo.Focus();

            }

        
        }


        public static void ValidarEmail_Validating(TextBox txt)
        {
            string valor = txt.Text.Trim();

            if (string.IsNullOrEmpty(valor))
            {
                ToolTipFactory.Configurar(true, ToolTipIcon.Error, "Erro de Validação");
                ToolTipFactory.Show("O campo E-mail é obrigatório.", txt, 2000);
                txt.Focus();
               
            }

            else if (!Regex.IsMatch(valor, emailRegex))
            {
                ToolTipFactory.Configurar(true, ToolTipIcon.Error, "Erro de Validação");
                ToolTipFactory.Show("Formato de e-mail inválido.", txt, 2000);
                txt.Focus();
                
            }

           
        }

        public static void ValidarCPF_Validating(MaskedTextBox txt)
        {
            string valor = txt.Text.Trim();

            // Remove a máscara
            txt.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            valor = txt.Text;

            if (string.IsNullOrEmpty(valor))
            {
                ToolTipFactory.Configurar(true, ToolTipIcon.Error, "Erro de Validação");
                ToolTipFactory.Show("O campo CPF é obrigatório.", txt, 2000);
                txt.Focus();

            }

            else if (!Regex.IsMatch(valor, cpfRegex))
            {
                ToolTipFactory.Configurar(true, ToolTipIcon.Error, "Erro de Validação");
                ToolTipFactory.Show("CPF inválido. Informe 11 números.", txt, 2000);
                txt.Focus();
            }

         
        }


        public static void ValidarTelefone_Validating(MaskedTextBox txt)
        {
            string valor = txt.Text.Trim();

            // Remove a máscara
            txt.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            valor = txt.Text;

            if (string.IsNullOrEmpty(valor))
            {
                ToolTipFactory.Configurar(true, ToolTipIcon.Error, "Erro de Validação");
                ToolTipFactory.Show("O campo Telefone é obrigatório.", txt, 2000);
                txt.Focus();
            }

            else if (!Regex.IsMatch(valor, telefoneRegex))
            {
                ToolTipFactory.Configurar(true, ToolTipIcon.Error, "Erro de Validação");
                ToolTipFactory.Show("Telefone inválido. Informe DDD + número com 10 ou 11 dígitos.", txt, 2000);
                txt.Focus();
               
            }

           
        }

    }
}
