using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppEPI.Entidades;

namespace AppEPI.Data
{
    public class EPIContext : DbContext
    {
        public EPIContext (DbContextOptions<EPIContext> options)
            : base(options)
        {
        }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<SolicitacaoProduto> SolicitacaoProduto { get; set; }
        public DbSet<Solicitacao> Solicitacao { get; set; }
        public DbSet<UF> UF { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<SolicitacaoProduto>()
                .HasKey(x => new { x.CodigoProduto, x.CodigoSolicitacao });

            builder.Entity<SolicitacaoProduto>()
                .HasOne(x => x.Solicitacao)
                .WithMany(y => y.Produtos)
                .HasForeignKey(x => x.CodigoSolicitacao);

            builder.Entity<SolicitacaoProduto>()
               .HasOne(x => x.Produto)
               .WithMany(y => y.Solicitacoes)
               .HasForeignKey(x => x.CodigoProduto);
        }
    }
}
