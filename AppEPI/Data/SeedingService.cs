using AppEPI.Entidades;
using System.Linq;

namespace AppEPI.Data
{
    public class SeedingService
    {
        private EPIContext _context;

        public SeedingService(EPIContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            if (_context.Categoria.Any())
            {
               return;
            }

            UF uf1 = new UF {Nome = "São Paulo"};
            UF uf2 = new UF { Nome = "Rio de Janeiro"};
            UF uf3 = new UF { Nome = "Brasilia" };
            UF uf4 = new UF { Nome = "Minas Gerais" };
            UF uf5 = new UF { Nome = "Parana" };
            UF uf6 = new UF { Nome = "Ceara" };
            UF uf7 = new UF { Nome = "Bahia" };
            UF uf8 = new UF { Nome = "Espirito Santo" };
            UF uf9 = new UF { Nome = "Goias" };
            _context.UF.AddRange(uf1, uf2, uf3, uf4, uf5, uf6, uf7, uf8, uf9);
            _context.SaveChanges();


            Categoria cat1 = new Categoria { Descricao = "Luvas de Segurança" };
            Categoria cat2 = new Categoria { Descricao = "Mascara de Segurança" };
            Categoria cat3 = new Categoria { Descricao = "Oculos de Segurança" };
            Categoria cat4 = new Categoria { Descricao = "Sapato de Segurança" };
            Categoria cat5 = new Categoria { Descricao = "Capaçete de Segurança" };
            _context.Categoria.AddRange(cat1, cat2, cat3, cat4, cat5);
            _context.SaveChanges();

            Produto prod1 = new Produto {Descricao = "Luvas Contra Impacto", CodigoCategoria=1};
            Produto prod2 = new Produto {Descricao = "Luvas anti Corte", CodigoCategoria= 1};
            Produto prod3 = new Produto { Descricao = "Mascara Círurgica", CodigoCategoria = 2};
            Produto prod4 = new Produto { Descricao = "Mascara de Pano", CodigoCategoria = 2};
            Produto prod5 = new Produto { Descricao = "Óculos de Sobreposição", CodigoCategoria = 3};
            Produto prod6 = new Produto { Descricao = "Óculos Ampla Visão", CodigoCategoria = 3};
            Produto prod7 = new Produto { Descricao = "Tênis de Segurança", CodigoCategoria = 4};
            Produto prod8 = new Produto { Descricao = "Botina de Segurança", CodigoCategoria = 4 };
            Produto prod9 = new Produto { Descricao = "Capacete Aba Total", CodigoCategoria = 5};
            Produto prod10 = new Produto { Descricao = "Capacete Aba Frontal", CodigoCategoria = 5};
            _context.Produto.AddRange(prod1, prod2, prod3, prod4, prod5, prod6, prod7, prod8, prod9, prod10);
            _context.SaveChanges();
        }
    }
}
