using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchMvc.Infra.Data.Migrations
{
    public partial class SeeProducts : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.InsertData(
                table: "Products",
                columns: new[]{ "Name", "Description", "Price", "Stock", "Image", "CategoryId" },
                values: new object[,]
                {
                    {"Caderno espiral", "caderno espiral 100 folhas" , 7.45, 50, "caderno1.png", 1},
                    {"Borracha", "Borracha Branca" , 3.25, 80, "borracha1.png", 1},
                    {"Calculadora escolar", "Calculadora simples" , 15.39, 20, "caderno1.png", 2}
                });
        }

        protected override void Down(MigrationBuilder mb)
        {
                mb.DropTable(
                name: "Products");
        }
    }
}
