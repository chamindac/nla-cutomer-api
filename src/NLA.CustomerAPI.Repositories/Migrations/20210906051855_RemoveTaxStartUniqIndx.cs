using Microsoft.EntityFrameworkCore.Migrations;

namespace NLA.CustomerAPI.Repositories.Migrations
{
    public partial class RemoveTaxStartUniqIndx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customer_TaxStartDate",
                table: "Customer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Customer_TaxStartDate",
                table: "Customer",
                column: "TaxStartDate",
                unique: true);
        }
    }
}
