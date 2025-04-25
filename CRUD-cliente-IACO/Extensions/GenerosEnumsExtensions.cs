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
                case GenerosEnum.H:
                    return "0";
                case GenerosEnum.M:
                    return "1";
                case GenerosEnum.O:
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
                    return GenerosEnum.H;
                case "1":
                    return GenerosEnum.M;
                case "2":
                    return GenerosEnum.O;
                default:
                    return GenerosEnum.O;
            }
        }
    }
}
