using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class FeedCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert INTO Categories(Name, ImageURL) Values('Bebidas','bebidas.jpg')");
            mb.Sql("INSERT INTO Categories(Name, ImageURL) Values('Lanches','lanches.jpg')");
            mb.Sql("INSERT INTO Categories(Name, ImageURL) Values('Sobremesas','soremesas.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Categories");
        }
    }
}
