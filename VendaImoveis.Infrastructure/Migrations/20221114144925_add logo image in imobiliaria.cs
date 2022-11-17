using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendaImoveis.Infrastructure.Migrations
{
    public partial class addlogoimageinimobiliaria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagemLogo",
                table: "Imobiliarias",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemLogo",
                table: "Imobiliarias");
        }
    }
}
