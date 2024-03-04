using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class FeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products(Name, Description, Price, ImageURL, Stock, RegistrationDate, CategoryId) " +
                "Values('Coca-Cola Zero','Lata de Refrigerante Coca-Cola Zero Açúcar 350ml','5.45','cocacola.jpg','50', now(),1)");

            mb.Sql("INSERT INTO Products(Name, Description, Price, ImageURL, Stock, RegistrationDate, CategoryId) " +
                "Values('Lanche de Atum','Lanche Natural de Atum com Maionese','8.50','atum.jpg','10', now(),2)");

            mb.Sql("INSERT INTO Products(Name, Description, Price, ImageURL, Stock, RegistrationDate, CategoryId) " +
                "Values('Bolo de Chocolate','Bolo de chocolate 150g','6.99','bolo.jpg','50', now(),3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products");
        }
    }
}
