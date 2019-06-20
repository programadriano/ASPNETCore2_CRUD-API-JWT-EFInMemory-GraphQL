using GraphQL.Types;

namespace APIProdutos.Models.Schemas
{
    public class ProdutoType : ObjectGraphType<Produto>
    {
        public ProdutoType()
        {
            Name = "Produto";

            Field(x => x.CodigoBarras).Description("Código de Barras");

            Field(x => x.Nome).Description("Nome do produto");

            Field(x => x.Preco).Description("Preço");

        }
    }
}
