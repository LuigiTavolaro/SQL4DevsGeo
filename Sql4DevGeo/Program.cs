using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Spatial;

//Exemplo retirado de https://msdn.microsoft.com/pt-br/library/jj900151.aspx

namespace Sql4DevGeo
{
    class Program
    {
        static void Main(string[] args)
        {
            //GeraBaseGeo();
            contexto ctx = new contexto();

            Console.WriteLine("---- Lojas e tipos ----");
            var tipos = ctx.Lojas.ToList();
            foreach (var l in tipos)
            {
                Console.WriteLine(l.Nome + " - " + l.Localizacao.SpatialTypeName);
            }
            


            Console.WriteLine("---- Lojas próximas + distancia ---");
            var meuLocal = DbGeography.FromText("POINT (-27.5855 -48.5507)");

            var lojas = ctx.Lojas
                        .OrderBy(l => l.Localizacao.Distance(meuLocal));
            foreach (var l in ctx.Lojas)
            {
                Console.WriteLine("Lojas próximas: {0} - Distancia: {1}",
                                    l.Nome,
                                    meuLocal.Distance(l.Localizacao));
            }

            Console.WriteLine("---- Localizar loja mais próxima ---");
            var maisProxima = ctx.Lojas
                                .OrderBy(l => l.Localizacao.Distance(meuLocal))
                                .FirstOrDefault();
            Console.WriteLine("Loja mais próxima é {0}",
                                maisProxima.Nome);


            Console.WriteLine("---- Localizar loja ---");
            DbGeography alvo = DbGeography.FromText("POINT (-27.585156 -48.549251)");
            var buscaLoja = ctx.Lojas
                .SingleOrDefault(l => l.Localizacao.Intersects(alvo));
            if (buscaLoja == null)
                Console.WriteLine("Loja não encontrada");
            else
                Console.WriteLine("Achou a loja {0}",
                                buscaLoja.Nome);


            Console.ReadLine();
        }

        private static void GeraBaseGeo()
        {
            contexto ctx = new contexto();
            ctx.Database.Initialize(true);

            // adicionar dados
            try
            {
                new List<Loja>{
                new Loja { Nome = "Loja roupas", Telefone="12312331",
                            Localizacao = DbGeography.FromText("POINT(-27.583748 -48.545560)")},
                new Loja { Nome = "Loja eletrônicos", Telefone="49238443",
                            Localizacao = DbGeography.FromText("POINT(-27.584433 -48.547148)")},
                new Loja { Nome = "Loja Bikes", Telefone="324234234",
                            Localizacao = DbGeography.FromText("POINT(-27.585156 -48.549251)")},
                new Loja { Nome = "Loja Kitesurf", Telefone="98475474",
                            Localizacao = DbGeography.FromText("POINT(-27.585764 -48.551053)")},
                new Loja { Nome = "Restaurante", Telefone="312345544",
                            Localizacao = DbGeography.FromText("POINT(-27.586183 -48.551869)")}
            }.ForEach(l => ctx.Lojas.Add(l));
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}

