using APIProdutos.Business;
using APIProdutos.Data;
using APIProdutos.Models;
using APIProdutos.Models.Schemas;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProdutos.Infra
{
    public class EatMoreQuery : ObjectGraphType
    {       

        public EatMoreQuery(ApplicationDbContext db)
        {

            Field<ListGraphType<ProdutoType>>(
                "produtos",
                resolve: context =>
                {
                    var produtos = db
                    .Produtos;
                    return produtos;
                });


            Field<ProdutoType>(
               "produto",
               arguments: new QueryArguments(
                   new QueryArgument<IdGraphType> { Name = "codigoDeBarras", Description = "Código do produto" }),
               resolve: context =>
               {
                   var codigoDeBarras = context.GetArgument<string>("codigoDeBarras");
                   var produto = db
                       .Produtos
                       .FirstOrDefault(i => i.CodigoBarras == codigoDeBarras);
                   return produto;
               });

        }
       
    }
}
