using LojaVirtual.ProdutoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.ProdutoApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet <Categoria> Categorias { get; set; }
        public DbSet <Produto> Produtos { get; set; }


        //Fluente API
        protected override void OnModelCreating(ModelBuilder mb )
        {
            //Categoria
            mb.Entity<Categoria>().HasKey(c => c.CategoriaId);

            mb.Entity<Categoria>()
                .Property(c => c.Name)
                    .HasColumnType("varchar(100)") // Define explicitamente o tipo
                        .HasMaxLength(100)
                            .IsRequired();

            //Produto
            mb.Entity<Produto>().
                Property(c => c.Name).
                    HasMaxLength(100).
                        IsRequired();
            mb.Entity<Produto>().
                Property(c => c.Description).
                    HasMaxLength(255).
                        IsRequired();
            mb.Entity<Produto>().
                Property(c => c.ImageURL).
                    HasMaxLength(255).
                        IsRequired();
            mb.Entity<Produto>().
                Property(c => c.Price).
                    HasPrecision(12,2).
                        IsRequired();
            mb.Entity<Categoria>().
                HasMany(g => g.Produtos).
                WithOne(c => c.Categoria).
                IsRequired().
                    OnDelete(DeleteBehavior.Cascade);

            mb.Entity<Categoria>().HasData(
                new Categoria
                {
                    CategoriaId = 1,
                    Name = "Eletronicos",
                },
                new Categoria
                {
                    CategoriaId = 2,
                    Name = "Roupas",
                }
                );
        }
    }
}
