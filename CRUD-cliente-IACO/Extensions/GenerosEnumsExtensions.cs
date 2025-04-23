using CRUD_cliente_IACO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD_cliente_IACO.Extensions
{
    public static class GenerosEnumsExtensions
    {
        public static string ToChar(this GenerosEnum genero)
        {
            switch (genero)
            {
                case GenerosEnum.Homem:
                    return "0";
                case GenerosEnum.Mulher:
                    return "1";
                case GenerosEnum.PrefiroNaoIdentificar:
                    return "2";
                default:
                    return "2";
            }
        }
    }
}
