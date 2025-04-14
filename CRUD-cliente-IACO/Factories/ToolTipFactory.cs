using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CRUD_cliente_IACO.Factories
{
    public static class ToolTipFactory
    {
        private static bool isBalloon = true;
        private static ToolTipIcon icon = ToolTipIcon.Warning;
        private static string title = "Validação";

        // Método público para exibir o tooltip
        public static void Show(string mensagem, Control controle, int tempo = 3000)
        {
            ToolTip toolTip = new ToolTip();

            toolTip.IsBalloon = isBalloon;
            toolTip.ToolTipIcon = icon;
            toolTip.ToolTipTitle = title;

            // Exibe o tooltip
            toolTip.Show(mensagem, controle, 0, controle.Height, tempo);
        }

        // Opcional: permite configurar o tooltip externamente
        public static void Configurar(bool usarBalao, ToolTipIcon icone, string titulo)
        {
            isBalloon = usarBalao;
            icon = icone;
            title = titulo;
        }
    }
}
