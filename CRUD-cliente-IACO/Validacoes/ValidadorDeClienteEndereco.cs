using CRUD_cliente_IACO.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CRUD_cliente_IACO.Validacoes
{
    class ValidadorDeClienteEndereco
    {

        private static string cepRegex = @"^\d{8}$"; // Ex: 12345678
        private static string bairroRegex = @"^[A-Za-zÀ-ÖØ-öø-ÿ\s'-]{3,50}$";
        private static string cidadeRegex = @"^[A-Za-zÀ-ÖØ-öø-ÿ\s'-]{2,50}$";
        private static string estadoRegex = @"^[A-Z]{2}$"; // Ex: SP, RJ, MG
        private static string ruaRegex = @"^[A-Za-zÀ-ÖØ-öø-ÿ0-9\s'°º.,-]{3,100}$";
        private static string numeroResidenciaRegex = @"^\d{1,6}$"; // Ex: 123, 45


        public static void ValidarCEP_KeyPress(MaskedTextBox txt, KeyPressEventArgs e)
        {

            // Permitir teclas de controle como Backspace, Delete, Tab etc.
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Permitir apenas letras (inclusive acentuadas)
            if (!char.IsNumber(e.KeyChar))
            {
                ToolTipFactory.Configurar(true, ToolTipIcon.Error, "Erro de Validação");
                ToolTipFactory.Show("Somente números são permitidas!", txt, 2000);
                e.Handled = true; // Bloqueia a tecla
            }
        }

        public static bool CEP_TextChanged(MaskedTextBox txt)
        {

            string valor = txt.Text.Trim();

            // Remove a máscara
            txt.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            valor = txt.Text;

            if (!Regex.IsMatch(valor, cepRegex))
            {
                ToolTipFactory.Configurar(true, ToolTipIcon.Error, "Erro de Validação");
                ToolTipFactory.Show("O campo CEP deve conter números (8 números).", txt, 2000);
                return false;

            }

            return true;
        }

        /*
        public static bool CEP_Leave(MaskedTextBox txt)
        {

            string valor = txt.Text.Trim();

            // Remove a máscara
            txt.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            valor = txt.Text;

            if (string.IsNullOrEmpty(valor))
            {
                ToolTipFactory.Configurar(true, ToolTipIcon.Error, "Erro de Validação");
                ToolTipFactory.Show("O campo CEP é obrigatório.", txt, 2000);
                txt.Focus();
                return false;

            }

            return true;
        }
        */

        public static void ValidarEstado_SelectedIndexChanged(ComboBox combo)
        {
            if (combo.SelectedIndex == 0)
            {
                ToolTipFactory.Configurar(true, ToolTipIcon.Error, "Erro de Validação");
                ToolTipFactory.Show("Selecione um Estado válido.", combo, 2000);
                combo.Focus();

            }

        }
    }
}
