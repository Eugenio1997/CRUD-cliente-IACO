using System;

namespace CRUD_cliente_IACO.AtributosCustomizados
{
    [AttributeUsage(AttributeTargets.Property)]
    class DisplayNameAttribute: Attribute
    {

        public string Nome { get; }

        public DisplayNameAttribute(string nome)
        {
            Nome = nome;
        }
    }
}
