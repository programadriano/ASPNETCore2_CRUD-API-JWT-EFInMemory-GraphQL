using APIProdutos.Business;
using APIProdutos.Models;
using APIProdutos.Models.Schemas;
using GraphQL;
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
                 });


            Field<ProdutoType>(
             "updateProduto",
             arguments: new QueryArguments(
                 new QueryArgument<NonNullGraphType<ProdutoInputType>> { Name = "produto" }),
             resolve: context =>
             {
                 var produtoParam = context.GetArgument<Produto>("produto");
                 var produto = produtoService.Obter(produtoParam.CodigoBarras);

                 if (produto == null)
                 {
                     context.Errors.Add(new ExecutionError("Não foi possível encontrar esse produto!"));
                     return null;
                 }

                 produtoService.Atualizar(produtoParam);
                 return $"Produto com o código:: {produto.CodigoBarras} atualizado com sucesso!";
             });



            Field<StringGraphType>(
            "deleteProduto",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "codigoBarras" }),
            resolve: context =>
            {
                var codigoBarras = context.GetArgument<string>("codigoBarras");
                var produto = produtoService.Obter(codigoBarras);

                if (produto == null)
                {
                    context.Errors.Add(new ExecutionError("Não foi possível encontrar esse produto!"));
                    return null;
                }

                produtoService.Excluir(produto.CodigoBarras);
                return $"Produto com o código:: {produto.CodigoBarras} deletado com sucesso!";
            }
);
        }
    }
}
