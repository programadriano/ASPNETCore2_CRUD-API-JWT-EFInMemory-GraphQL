using APIProdutos.Business;
using APIProdutos.Models;
using APIProdutos.Models.Schemas;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProdutos.Infra
{
    public class AppMutation : ObjectGraphType
    {


        public AppMutation(ProdutoService produtoService)
        {

            Field<ProdutoType>(
                 "addProduto",
                 arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ProdutoInputType>>
                 {
                     Name = "produto"
                 }
                 ),
                 resolve: context =>
                 {
                     var produto = context.GetArgument<Produto>("produto");
                     produtoService.Incluir(produto);
                     return produtoService.Obter(produto.CodigoBarras);
                 }
       );
        }
    }
}
