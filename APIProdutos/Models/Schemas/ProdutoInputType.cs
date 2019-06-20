using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProdutos.Models.Schemas
{
    public class ProdutoInputType : InputObjectGraphType
    {
        public ProdutoInputType()
        {
            Name = "produtoInput";
            Field<NonNullGraphType<StringGraphType>>("codigoBarras");
            Field<NonNullGraphType<StringGraphType>>("nome");
            Field<NonNullGraphType<DecimalGraphType>>("preco");
        }
    }
}
