using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaVirtual.ProdutoApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb) //migrationsbuildes
        {
            mb.Sql("Insert into produtos(Name,Price,Description, Stock, ImageURL, CategoriaId)" +
                "Values('Caixa de Som' ,890.00,'JBL',  9, 'caixadesom1.jpg', 1)");

            mb.Sql("Insert into produtos(Name,Price,Description, Stock, ImageURL, CategoriaId)" +
                "Values('Iphone' , 3500.00,'Iphone 13', 15, 'Iphone13.jpg', 1)");

            mb.Sql("Insert into produtos(Name,Price,Description, Stock, ImageURL, CategoriaId)" +
                "Values('Camisa' ,120.00,'Moletom',  20, 'moletom.jpg', 2)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from produtos");
        }
    }
}
