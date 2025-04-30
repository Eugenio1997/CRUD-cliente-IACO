using CRUD_cliente_IACO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD_cliente_IACO.Extensions
{
    public static class GenerosEnumsExtensions
    {
        public static string ParaChar(this GenerosEnum genero)
        {
            switch (genero)
            {
                case GenerosEnum.Homem:
                    return "0";
                case GenerosEnum.Mulher:
                    return "1";
                case GenerosEnum.Outros:
                    return "2";
                default:
                    return "2";
            }
        }

        public static GenerosEnum ParaGenerosEnum(this string genero)
        {
            switch (genero)
            {
                case "0":
                    return GenerosEnum.Homem;
                case "1":
                    return GenerosEnum.Mulher;
                case "2":
                    return GenerosEnum.Outros;
                default:
                    return GenerosEnum.Outros;
            }
        }
    }
}
